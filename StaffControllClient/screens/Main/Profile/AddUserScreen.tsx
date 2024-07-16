import React, { useEffect, useState } from "react";
import { Image, SafeAreaView, ScrollView, StyleSheet, Text, TouchableOpacity, View } from "react-native";
import { ServerUrl, backgroundColor, blackColor, inputFieldColor, whiteColor, windowWidth } from "../../../_helpers/constant";
import { useIsFocused, useNavigation } from "@react-navigation/native";
import Input from "../../../_helpers/components/InputComponent";
import Button from "../../../_helpers/components/ButtonComponent";
import SelectDropdown from "react-native-select-dropdown";
import { ActivityIndicator } from "react-native";
import AsyncStorage from "@react-native-async-storage/async-storage";

interface User {
    email: string;
    username: string;
    firstName: string;
    lastName: string;
    parentUserId: string;
    roles: Role[];
}

interface Role {
    id: string;
}

interface GetRole {
    name: string;
    department: GetDepartment;
    userRoles: GetUserRole[];
    id: string;
}

interface GetDepartment {
    name: string;
}

interface GetUserRole {
    user: GetUser;
}

interface GetUser {
    email: string;
    username: string;
    firstName: string;
    lastName: string;
    file: string | undefined;
    id: string;
}


export default function AddUserScreen() {
    const isFocused = useIsFocused()
    const navigation = useNavigation()

    const [loading, setLoading] = useState(true)
    const [roles, setRoles] = useState<GetRole[]>()
    const [user, setUser] = useState<User>({
        email: "",
        username: "",
        firstName: "",
        lastName: "",
        parentUserId: "",
        roles: [],
    })

    useEffect(() => {
        if (isFocused) {
            GetRoles()
        }
    }, [isFocused])

    const GetRoles = async () => {
        setLoading(true)
        const options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
            }
        }
        let url = ServerUrl + '/api/Roles/getRoles';
        await fetch(url, options)
            .then((response) => response.json())
            .then(response => {
                setRoles(response)
                setLoading(false)
            })
            .catch(response => console.log(response))
    }

    const OnType = (value: string, property: string) => {
        setUser(prevState => ({
            ...prevState,
            [property]: value,
        }));
    };

    const OnChangeSelectedItem = (value: string, property: string) => {
        setUser(prevState => ({
            ...prevState,
            [property]: [{
                id: value
            }],
        }));
    }

    const getToken = async () => {
        const value = await AsyncStorage.getItem('@access_token');
        return value != null ? JSON.parse(value) : null;
    }

    const AddUser = async() => {
        let access_token = await getToken()
        const options = {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            },
            body: JSON.stringify(user)
        }

        let url = ServerUrl + `/api/Users/addUser`;
        await fetch(url, options)
            .then(response => navigation.goBack())
            .catch(response => console.log(response))
    }

    return (
        <ScrollView style={styles.main}>
            {loading ? (
                <ActivityIndicator />
            ) : (
                <View style={styles.view}>
                    <Input onTypeText={OnType} placeholderText="Почта" propertyName="email" multiline={false} />
                    <Input onTypeText={OnType} placeholderText="Имя пользователя" propertyName="username" multiline={false} />
                    <Input onTypeText={OnType} placeholderText="Имя" propertyName="firstName" multiline={false} />
                    <Input onTypeText={OnType} placeholderText="Фамилия" propertyName="lastName" multiline={false} />
                    <View style={styles.inputView}>
                        <SelectDropdown
                            data={roles as GetRole[]}
                            onSelect={(selectedItem, index) => {
                                OnChangeSelectedItem(selectedItem.id, "roles")
                            }}
                            renderButton={(selectedItem, isOpened) => {
                                return (
                                    <View style={styles.dropdownButtonStyle}>
                                        <Text style={styles.dropdownButtonTxtStyle}>
                                            {(selectedItem && selectedItem.name) || 'Роль'}
                                        </Text>
                                    </View>
                                );
                            }}
                            renderItem={(item, index, isSelected) => {
                                return (
                                    <View style={{ ...styles.dropdownItemStyle, ...(isSelected && { backgroundColor: '#D2D9DF' }) }}>
                                        <View style={{ paddingHorizontal: 10 }}>
                                            <Text style={styles.dropdownItemTxtStyle}>{item.name}</Text>
                                            {
                                                item.department !== undefined ? (<Text>{item.department.name}</Text>) : null
                                            }
                                        </View>
                                    </View>
                                );
                            }}
                            showsVerticalScrollIndicator={false}
                            dropdownStyle={styles.dropdownMenuStyle}
                        />
                    </View>

                    <Button text="Подтвердить" onClick={AddUser} />
                </View>
            )}
        </ScrollView>
    )
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        backgroundColor: backgroundColor,
    },

    view: {
        flex: 1,
        width: windowWidth,
        marginBottom: 5,
        padding: 10,
        alignItems: 'center'
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
        borderRadius: 10,
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
    inputView: {
        alignItems: 'center',
    },
})