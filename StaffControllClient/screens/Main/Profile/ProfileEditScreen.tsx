import React, { useEffect, useState } from "react";
import { StyleSheet, Text, View } from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";
import { ServerUrl, backgroundColor, inputFieldColor, whiteColor, windowWidth } from "../../../_helpers/constant";
import Input from "../../../_helpers/components/InputComponent";
import AsyncStorage from "@react-native-async-storage/async-storage";
import Button from "../../../_helpers/components/ButtonComponent";
import { useNavigation } from "@react-navigation/native";

interface User {
    firstName: string,
    lastName: string,
}

export default function ProfileEdit() {
    const navigation = useNavigation()

    const [user, setUser] = useState<User>({
        firstName: '',
        lastName: '',
    });

    useEffect(() => {
        getUserData()
    }, [])

    const getToken = async () => {
        const value = await AsyncStorage.getItem('@access_token');
        return value != null ? JSON.parse(value) : null;
    }

    const getUserData = async () => {
        let access_token = await getToken()
        const options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            }
        }
        let url = ServerUrl + '/api/Users/current';
        await fetch(url, options)
            .then((response) => response.json())
            .then((response) => {
                setUser(response)
            })
    }

    const onChangeUserData = async () => {
        let access_token = await getToken()
        const options = {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            },
            body: JSON.stringify(user),
        }
        let url = ServerUrl + '/api/Users/edit';
        await fetch(url, options)
            .then(() => navigation.navigate("Profile" as never))

    }

    const OnType = (value: string, property: string) => {
        setUser(prevState => ({
            ...prevState,
            [property]: value,
        }));
    };

    return (
        <SafeAreaView style={styles.main}>
            <View>
                <View style={styles.inputFieldView}>
                    <Text style={{ color: whiteColor }}>
                        Имя
                    </Text>
                    <Input placeholderText={user?.firstName as string} propertyName="firstName" onTypeText={OnType} multiline={false} />
                </View>
                <View style={styles.inputFieldView}>
                    <Text style={{ color: whiteColor }}>
                        Фамилия
                    </Text>
                    <Input placeholderText={user?.lastName as string} propertyName="lastName" onTypeText={OnType} multiline={false} />
                </View>
            </View>
            <Button text="Сохранить" onClick={() => onChangeUserData()} />
        </SafeAreaView>
    )
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        backgroundColor: backgroundColor,
        paddingHorizontal: 10,
        paddingVertical: 10,
        alignItems: 'center'
    },

    photoView: {
        width: windowWidth - 20,
        height: windowWidth - 20
    },

    inputFieldView: {
        // flexDirection: 'row',
        // justifyContent: 'space-between',
        alignItems: 'center',
        width: windowWidth - 20,
        marginBottom: 10,
    },

    inputField: {
        width: windowWidth / 1.2,
        paddingHorizontal: 10,
        marginVertical: 5,
        color: whiteColor,
        backgroundColor: inputFieldColor,
        borderRadius: 10,
    },
})