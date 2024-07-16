import React from "react";
import { ActivityIndicator, Image, Modal, ScrollView, StyleSheet, Text, TouchableOpacity, TouchableWithoutFeedback, View } from "react-native";
import { ServerUrl, backgroundColor, blackColor, filterVisible, inputFieldColor, selectedTask, whiteColor, windowWidth } from "../../../_helpers/constant";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useEffect, useState } from "react";
import { useIsFocused, useNavigation } from "@react-navigation/native";
import { useAtom } from "jotai";
import DatePicker from "react-native-date-picker";
import SelectDropdown from "react-native-select-dropdown";
import Button from "../../../_helpers/components/ButtonComponent";

interface Filter {
    startDate: string | undefined,
    endDate: string | undefined,
    toDoStatus: number | undefined
}

interface PageDto {
    items: Task[];
    pageViewModel: {
        pageNumber: number;
        totalPages: number;
        hasPreviousPage: boolean;
        hasNextPage: boolean
    }
}

interface Task {
    id: string,
    dateCreated: Date,
    startDate: Date,
    endDate: Date,
    status: number,
    author: User,
    responsible: User,
    name: string,
    description: string,
}

interface User {
    id: string;
    firstName: string;
    lastName: string;
    file: File;
    userRoles: {
        role: Role
    }[],
}

interface Role {
    id: string,
    name: string,
    parentRole: Role,
}

interface File {
    fileExtension: string;
    fileBase64: string;
}

const profileImage = require('./../../../public/img/profile.png')

export default function TaskScreen() {
    const isFocused = useIsFocused()
    const navigation = useNavigation()

    const today = new Date()
    const tomorrow = new Date()
    tomorrow.setDate(tomorrow.getDate() + 1)
    tomorrow.setHours(0, 0, 0, 0);

    const [visible, setVisible] = useAtom(filterVisible)
    const [isAuthor, setIsAuthor] = useState(true)

    const [selectedTaskId, setSelectedTaskId] = useAtom(selectedTask)
    const [loading, setLoading] = useState(true);
    const [pageNumber, setPageNumber] = useState<number>(1);
    const [pageDto, setPageDto] = useState<PageDto>();
    const [endDateOpen, setEndDateOpen] = useState(false)
    const [startDateOpen, setStartDateOpen] = useState(false)
    const [filter, setFilter] = useState<Filter>({
        startDate: today.toDateString(),
        endDate: tomorrow.toISOString(),
        toDoStatus: undefined,
    });

    const statusData = [
        {
            id: 0,
            name: "В ожиданий",
        },
        {
            id: 1,
            name: "В работе",
        },
        {
            id: 2,
            name: "На рассмотрении",
        },
        {
            id: 3,
            name: "Отменено",
        },
        {
            id: 4,
            name: "Завершено",
        },
    ]

    const OnType = (value: string | Date | number | null, property: string) => {
        setFilter(prevState => ({
            ...prevState,
            [property]: value,
        }));
        console.log(filter)
    };

    useEffect(() => {
        if (isFocused) {
            setPageNumber(1)
            GetTasks({
                startDate: undefined,
                endDate: undefined,
                toDoStatus: undefined,
            })
        }
    }, [isFocused])

    useEffect(() => {
        setPageNumber(1)
        GetTasks({
            startDate: undefined,
            endDate: undefined,
            toDoStatus: undefined,
        })
    }, [isAuthor])

    const getToken = async () => {
        const value = await AsyncStorage.getItem('@access_token');
        return value != null ? JSON.parse(value) : null;
    }

    const GetTasks = async (filter: Filter) => {
        setLoading(true)
        let access_token = await getToken()
        const options = {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            },
            body: JSON.stringify(filter)
        }

        let endpoint = isAuthor ? '/api/ToDoes/getAuthorTasks' : '/api/ToDoes/getResponsibleTasks'
        let url = ServerUrl + `${endpoint}?page=${pageNumber}`;
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

    return (
        <ScrollView style={styles.main}>
            {loading ? (<ActivityIndicator size={'large'} color={'white'} style={{ flex: 1 }} />) : (
                pageDto?.items?.map(todo =>
                    <TouchableOpacity key={todo.id} style={styles.todoView} onPress={() => {
                        setSelectedTaskId(todo.id)
                        navigation.navigate('SelectedTaskScreen' as never)
                    }}>
                        <View style={{ flexDirection: 'row', alignItems: 'center', marginBottom: 5 }}>
                            <Image source={todo.author?.file ? { uri: `data:image/${todo.author?.file.fileExtension};base64,` + todo.author?.file.fileBase64 } : profileImage} style={{ width: 30, height: 30, borderRadius: 30 / 2 }} />
                            <Text style={styles.todoAuthor}>{todo.author.firstName} {todo.author.lastName}</Text>
                        </View>
                        <Text style={styles.todoName}>{todo.name}</Text>
                    </TouchableOpacity>
                )
            )}
            <Modal
                animationType="slide"
                transparent={true}
                visible={visible}
                onRequestClose={() => {
                    setVisible(false);
                }}
            >
                <TouchableWithoutFeedback onPress={() => setVisible(false)}>
                    <View style={styles.modalContainer}>
                        <View style={styles.modalContent}>
                            <View>
                                <Text style={styles.label}>Роль</Text>
                                <View style={styles.roleSelector}>
                                    <TouchableOpacity style={[styles.roleBtn, { backgroundColor: isAuthor ? whiteColor : inputFieldColor }]} onPress={() => setIsAuthor(!isAuthor)}>
                                        <Text style={{ color: isAuthor ? blackColor : whiteColor }}>Автор</Text>
                                    </TouchableOpacity>
                                    <TouchableOpacity style={[styles.roleBtn, { backgroundColor: !isAuthor ? whiteColor : inputFieldColor }]} onPress={() => setIsAuthor(!isAuthor)}>
                                        <Text style={{ color: !isAuthor ? blackColor : whiteColor }}>Исполнитель</Text>
                                    </TouchableOpacity>
                                </View>
                            </View>

                            <View>
                                <View style={styles.roleSelector}>
                                    <View>
                                        <Text style={styles.label}>Дата начала</Text>
                                        <TouchableOpacity style={styles.datePicker} onPress={() => setStartDateOpen(true)}>
                                            <Text style={{ color: whiteColor, fontSize: 16 }}>
                                                {new Date(filter.startDate as string).toLocaleDateString('ru-RU', {
                                                    day: '2-digit',
                                                    month: '2-digit',
                                                    year: 'numeric',
                                                })}
                                            </Text>
                                            <DatePicker
                                                modal
                                                open={startDateOpen}
                                                date={new Date(filter.startDate as string)}
                                                maximumDate={today}
                                                theme="dark"
                                                mode="date"
                                                onConfirm={(date) => {
                                                    date.setHours(0, 0, 0, 0);
                                                    OnType(date.toISOString(), "startDate")
                                                    setStartDateOpen(false)
                                                }}
                                                onCancel={() => {
                                                    setStartDateOpen(false)
                                                }} />
                                        </TouchableOpacity>
                                    </View>

                                    <View>
                                        <Text style={styles.label}>Дата окончания</Text>
                                        <TouchableOpacity style={styles.datePicker} onPress={() => setEndDateOpen(true)}>
                                            <Text style={{ color: whiteColor, fontSize: 16 }}>
                                                {new Date(filter.endDate as string).toLocaleDateString('ru-RU', {
                                                    day: '2-digit',
                                                    month: '2-digit',
                                                    year: 'numeric',
                                                })}
                                            </Text>
                                            <DatePicker
                                                modal
                                                open={endDateOpen}
                                                date={new Date(filter.endDate as string)}
                                                minimumDate={today}
                                                theme="dark"
                                                mode="date"
                                                onConfirm={(date) => {
                                                    date.setHours(23, 59, 59);
                                                    OnType(date.toISOString(), "endDate")
                                                    setEndDateOpen(false)
                                                }}
                                                onCancel={() => {
                                                    setEndDateOpen(false)
                                                }} />
                                        </TouchableOpacity>
                                    </View>
                                </View>
                            </View>

                            <View>
                                <Text style={styles.label}>Статус</Text>
                                <View style={styles.roleSelector}>
                                    <SelectDropdown
                                        data={statusData}
                                        onSelect={(selectedItem, index) => {
                                            OnType(selectedItem.id, "toDoStatus")
                                        }}
                                        renderButton={(selectedItem, isOpened) => {
                                            return (
                                                <View style={styles.dropdownButtonStyle}>
                                                    <Text style={styles.dropdownButtonTxtStyle}>
                                                        {(selectedItem && selectedItem.name) || 'Статус'}
                                                    </Text>
                                                </View>
                                            );
                                        }}
                                        renderItem={(item, index, isSelected) => {
                                            return (
                                                <View style={{ ...styles.dropdownItemStyle, ...(isSelected && { backgroundColor: '#D2D9DF' }) }}>
                                                    <View style={{ paddingHorizontal: 10 }}>
                                                        <Text style={styles.dropdownItemTxtStyle}>{item.name}</Text>
                                                    </View>
                                                </View>
                                            );
                                        }}
                                        showsVerticalScrollIndicator={false}
                                        dropdownStyle={styles.dropdownMenuStyle}
                                    />
                                </View>
                            </View>
                            <Button text='Применить' onClick={() => GetTasks(filter)} />

                            <Button text='Сбросить' onClick={() => {
                                setFilter({
                                    startDate: today.toDateString(),
                                    endDate: tomorrow.toISOString(),
                                    toDoStatus: undefined,
                                })
                                GetTasks({
                                    startDate: undefined,
                                    endDate: undefined,
                                    toDoStatus: undefined,
                                })
                            }} />
                        </View>
                    </View>

                </TouchableWithoutFeedback>
            </Modal>
        </ScrollView>
    )
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        backgroundColor: backgroundColor
    },

    todoView: {
        backgroundColor: blackColor,
        paddingHorizontal: 10,
        paddingVertical: 10,
        marginBottom: 10
    },

    todoName: {
        color: whiteColor,
        fontSize: 18,
        fontWeight: 'bold'
    },

    todoAuthor: {
        color: whiteColor,
        paddingHorizontal: 10
    },

    modalContainer: {
        flex: 1,
        justifyContent: 'flex-end',
        backgroundColor: 'rgba(0, 0, 0, 0.5)',
    },

    modalContent: {
        backgroundColor: backgroundColor,
        padding: 30,
        borderTopLeftRadius: 10,
        borderTopRightRadius: 10,
        paddingHorizontal: 40,
        alignItems: 'center'
    },

    label: {
        color: whiteColor,
        fontSize: 16,
        fontWeight: '700'
    },

    roleSelector: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        paddingVertical: 5,
        width: '100%'
    },

    roleBtn: {
        backgroundColor: inputFieldColor,
        alignItems: 'center',
        width: '50%',
        padding: 10,
    },

    datePicker: {
        backgroundColor: inputFieldColor,
        width: windowWidth / 3,
        paddingHorizontal: 10,
        paddingVertical: 10,
        marginVertical: 5,
    },

    dropdownButtonStyle: {
        height: 50,
        flexDirection: 'row',
        justifyContent: 'center',
        alignItems: 'center',
        width: '100%',
        paddingHorizontal: 10,
        marginVertical: 5,
        color: whiteColor,
        backgroundColor: inputFieldColor,
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
})