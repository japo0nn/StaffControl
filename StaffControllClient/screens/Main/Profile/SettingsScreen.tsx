import React, { useEffect, useState } from "react";
import { SafeAreaView, StyleSheet, Switch, Text, TouchableOpacity, View } from "react-native";
import { ServerUrl, backgroundColor, blackColor, secondColor, signed, whiteColor, windowWidth } from "../../../_helpers/constant";
import { useIsFocused, useNavigation } from "@react-navigation/native";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useAtom } from "jotai";

export default function SettingsScreen() {
    const navigation = useNavigation()
    const isFocused = useIsFocused()
    const [signedIn, setSignedIn] = useAtom(signed)
    const [switchEnabled, setSwitchEnabled] = useState(false);

    const [isAdmin, setIsAdmin] = useState(false)

    useEffect(() => {
        if (isFocused) {
            Get2FAStatus()
            CheckAdminRole()
        }
    }, [isFocused])

    const getToken = async () => {
        const value = await AsyncStorage.getItem('@access_token');
        return value != null ? JSON.parse(value) : null;
    }

    const Get2FAStatus = async () => {
        let access_token = await getToken()
        const options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            }
        }
        let url = ServerUrl + '/api/Users/check2FA';
        await fetch(url, options)
            .then((response) => {
                if (response.status === 200) setSwitchEnabled(true)
            })
    }

    const CheckAdminRole = async() => {
        let access_token = await getToken()
        const options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            }
        }
        let url = ServerUrl + '/api/Users/isAdmin';
        await fetch(url, options)
            .then((response) => {
                if (response.status === 200) setIsAdmin(true)
            })
    }

    const toggleSwitch = () => {
        navigation.navigate('ProfileNavigation', { screen: 'TwoFactorScreen' });
    }

    return (
        <SafeAreaView style={styles.main}>
            <TouchableOpacity style={styles.view} onPress={() => navigation.navigate('ChangePassword' as never)}>
                <Text style={{ color: whiteColor, fontSize: 18 }}>Изменить пароль</Text>
            </TouchableOpacity>
            {isAdmin ? (
            <TouchableOpacity style={styles.view} onPress={() => navigation.navigate('AddUserScreen' as never)}>
                <Text style={{ color: whiteColor, fontSize: 18 }}>Добавить пользователя</Text>
            </TouchableOpacity>) : null}
            <View style={styles.view}>
                <Text style={{ color: whiteColor, fontSize: 18, width: 300 }}>Включить 2FA</Text>
                <Switch
                    trackColor={{ false: secondColor, true: whiteColor }}
                    thumbColor={switchEnabled ? secondColor : whiteColor}
                    ios_backgroundColor="#3e3e3e"
                    onValueChange={toggleSwitch}
                    value={switchEnabled}
                />
            </View>
            <TouchableOpacity style={styles.view} onPress={() =>
                AsyncStorage.removeItem('@access_token').then(() => {
                    setSignedIn(false)
                })
            }>
                <Text style={{ color: 'red', fontSize: 18 }}>Выйти</Text>
            </TouchableOpacity>
        </SafeAreaView>
    )
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        backgroundColor: backgroundColor,
    },

    view: {
        width: windowWidth,
        backgroundColor: blackColor,
        marginBottom: 5,
        padding: 10,
        justifyContent: 'space-between',
        flexDirection: 'row'
    }
})