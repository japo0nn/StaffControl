import React from "react";
import { ScrollView, StyleSheet, Text, View, Image, TouchableOpacity } from "react-native";
import { ServerUrl, backgroundColor, inputFieldColor, whiteColor, windowWidth } from "../../../_helpers/constant";
import Input from "../../../_helpers/components/InputComponent";
import { JSXElementConstructor, Key, ReactElement, ReactNode, ReactPortal, useEffect, useState } from "react";
import { useIsFocused, useNavigation } from "@react-navigation/native";
import AsyncStorage from "@react-native-async-storage/async-storage";
import SelectDropdown from 'react-native-select-dropdown'
import DatePicker from 'react-native-date-picker'
import Button from "../../../_helpers/components/ButtonComponent";

interface PageDto {
    items: User[];
    pageViewModel: {
        pageNumber: number;
        totalPages: number;
        hasPreviousPage: boolean;
        hasNextPage: boolean
    }
}

interface User {
    id: string,
    email: string,
    username: string,
    firstName: string,
    lastName: string,
    userRoles: {
        role: Role
    }[],
    file: UserImage
}

interface Role {
    id: string,
    name: string,
}

interface UserImage {
    fileBase64: string,
    fileExtension: string,
    name: string
}

interface Task {
    endDate: string,
    responsibleId: string,
    name: string,
    description: string,
    status: number
}

const profileImage = require('./../../../public/img/profile.png')

export default function NewTaskScreen() {
    const isFocused = useIsFocused();
    const navigation = useNavigation();
    const tomorrow = new Date()
    tomorrow.setDate(tomorrow.getDate() + 1)
    tomorrow.setHours(0, 0, 0, 0);

    const [pageDto, setPageDto] = useState<PageDto>();
    const [loading, setLoading] = useState(true)
    const [pageNumber, setPageNumber] = useState(1);
    const [endDateOpen, setEndDateOpen] = useState(false)
    const [todo, setTodo] = useState<Task>({
        endDate: tomorrow.toString(),
        responsibleId: "",
        name: "",
        description: "",
        status: 0
    })

    const OnType = (value: string | Date, property: string) => {
        setTodo(prevState => ({
            ...prevState,
            [property]: value,
        }));
    };

    useEffect(() => {
        if (isFocused) {
            GetUsersList()
        }
    }, [isFocused])

    const getToken = async () => {
        const value = await AsyncStorage.getItem('@access_token');
        return value != null ? JSON.parse(value) : null;
    }

    const GetUsersList = async () => {
        setLoading(true)
        let access_token = await getToken()
        const options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            }
        }
        let url = ServerUrl + `/api/Users/getUsersList?page=${pageNumber}`;
        await fetch(url, options)
            .then((response) => response.json())
            .then((response) => {
                setPageDto(response)
                setLoading(false)
                if (response.pageViewModel.hasNextPage) {
                    setPageNumber(pageNumber + 1)
                }
            })
    }

    const CreateTodo = async() => {
        let access_token = await getToken()
        const options = {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            },
            body: JSON.stringify(todo)
        }
        let url = ServerUrl + `/api/ToDoes/create`;
        console.log(options.body)
        await fetch(url, options)
            .then(response => navigation.navigate('TaskScreen' as never))
    }

    return (
        <ScrollView style={styles.main}>
            <View style={styles.inputContainer}>

                <Text style={styles.inputLabel}>Название задачи</Text>
                <View style={styles.inputView}>
                    <Input placeholderText="Название задачи" multiline={false} propertyName="name" onTypeText={OnType} />
                </View>
                <Text style={styles.inputLabel}>Описание задачи</Text>
                <View style={styles.inputView}>
                    <Input placeholderText="Описание задачи" multiline={true} propertyName="description" onTypeText={OnType} />
                </View>
                <Text style={styles.inputLabel}>Исполнитель</Text>
                <View style={styles.inputView}>
                    <SelectDropdown
                        data={pageDto?.items as any}
                        onSelect={(selectedItem, index) => {
                            OnType(selectedItem.id, "responsibleId")
                        }}
                        renderButton={(selectedItem, isOpened) => {
                            return (
                                <View style={styles.dropdownButtonStyle}>
                                    {selectedItem && (
                                        <Image source={selectedItem.file ? { uri: `data:image/${selectedItem.file.fileExtension};base64,` + selectedItem.file.fileBase64 } : profileImage} style={{ width: 50, height: 50, borderRadius: 25 }} />
                                    )}
                                    <Text style={styles.dropdownButtonTxtStyle}>
                                        {(selectedItem && selectedItem.lastName + " " + selectedItem.firstName) || 'Исполнитель'}
                                    </Text>
                                </View>
                            );
                        }}
                        renderItem={(item, index, isSelected) => {
                            return (
                                <View style={{ ...styles.dropdownItemStyle, ...(isSelected && { backgroundColor: '#D2D9DF' }) }}>
                                    <Image source={item.file ? { uri: `data:image/${item.file.fileExtension};base64,` + item.file.fileBase64 } : profileImage} style={{ width: 50, height: 50, borderRadius: 25 }} />
                                    <View style={{ paddingHorizontal: 10 }}>
                                        <Text style={styles.dropdownItemTxtStyle}>{item.lastName} {item.firstName}</Text>
                                        {item.userRoles.map((userRole: { role: Role; }) =>
                                            <Text key={userRole.role.id}>{userRole.role.name}</Text>
                                        )}
                                    </View>
                                </View>
                            );
                        }}
                        showsVerticalScrollIndicator={false}
                        dropdownStyle={styles.dropdownMenuStyle}
                    />
                </View>
                <Text style={styles.inputLabel}>Дата окончания</Text>
                <View style={styles.inputView}>
                    <TouchableOpacity style={styles.datePicker} onPress={() => setEndDateOpen(true)}>
                        <Text style={{ color: whiteColor, fontSize: 16 }}>
                            {new Date(todo.endDate).toLocaleDateString('ru-RU', {
                                day: '2-digit',
                                month: '2-digit',
                                year: 'numeric',
                            })}
                        </Text>
                        <DatePicker
                            modal
                            open={endDateOpen}
                            date={new Date(todo.endDate)}
                            minimumDate={tomorrow}
                            theme="dark"
                            mode="date"
                            onConfirm={(date) => {
                                OnType(date.toISOString(), "endDate")
                                setEndDateOpen(false)
                            }}
                            onCancel={() => {
                                setEndDateOpen(false)
                            }} />
                    </TouchableOpacity>
                </View>
                <View style={styles.inputView}>
                    <Button onClick={CreateTodo} text="Создать"/>
                </View>
            </View>
        </ScrollView>
    )
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        backgroundColor: backgroundColor,
        paddingHorizontal: 10,
        paddingVertical: 10,
    },

    inputContainer: {
        flex: 1,
    },

    inputLabel: {
        color: whiteColor,
        textAlign: 'left',
        paddingHorizontal: 10,
    },

    inputView: {
        alignItems: 'center',
    },

    dropdownButtonStyle: {
        height: 60,
        flexDirection: 'row',
        justifyContent: 'center',
        alignItems: 'center',
        width: windowWidth - 40,
        paddingHorizontal: 10,
        marginVertical: 5,
        color: whiteColor,
        backgroundColor: inputFieldColor,
        borderRadius: 10,
    },
    dropdownButtonTxtStyle: {
        flex: 1,
        fontSize: 18,
        fontWeight: '500',
        color: whiteColor,
        paddingHorizontal: 10
    },
    dropdownButtonArrowStyle: {
        fontSize: 28,
    },
    dropdownButtonIconStyle: {
        fontSize: 28,
        marginRight: 8,
    },
    dropdownMenuStyle: {
        backgroundColor: '#E9ECEF',
        borderRadius: 8,
    },
    dropdownItemStyle: {
        width: '100%',
        flexDirection: 'row',
        paddingHorizontal: 12,
        alignItems: 'center',
        paddingVertical: 8,
    },
    dropdownItemTxtStyle: {
        flex: 1,
        fontSize: 18,
        fontWeight: '500',
        color: '#151E26',
    },
    dropdownItemIconStyle: {
        fontSize: 28,
        marginRight: 8,
    },

    datePicker: {
        backgroundColor: inputFieldColor,
        width: windowWidth - 40,
        paddingHorizontal: 10,
        paddingVertical: 10,
        marginVertical: 5,
        borderRadius: 10,
    }
})