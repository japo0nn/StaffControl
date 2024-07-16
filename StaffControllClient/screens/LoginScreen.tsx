import React, { useState } from "react";
import { Alert, Image, StyleSheet, View } from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";
import { ServerUrl, backgroundColor, signed, token, userID, windowWidth } from "../_helpers/constant";
import Button from "../_helpers/components/ButtonComponent";
import Input from "../_helpers/components/InputComponent";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useAtom } from "jotai";
import { useNavigation } from "@react-navigation/native";

const logoImg = require('./../public/img/logo.png')

export default function Auth() {
    const navigation = useNavigation()
    const [signedIn, setSignedIn] = useAtom(signed)
    const [userToken, setUserToken] = useAtom(token)
    const [loginModel, setLoginModel] = useState({
        username: '',
        password: '',
    });


    const onLoginClick = async () => {
        if (loginModel.username != "" && loginModel.password != "") {
            const options = {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(loginModel)
            }
            let url = ServerUrl + '/api/Users/login';
            console.log(url)
            console.log(options.body)
            await fetch(url, options)
                .then((response) => response.json())
                .then(async (response) => {
                    let token = response.access_token;
                    setUserToken(token)
                    const verifyOptions = {
                        method: "GET",
                        headers: {
                            "Content-Type": "application/json",
                            Authorization: "Bearer " + token,
                        }
                    }
                    await fetch(ServerUrl + '/api/Users/check2FA', verifyOptions)
                        .then((response) => {
                            console.log(response.status)
                            if (response.status === 200) { navigation.navigate('LoginTwoFactorScreen' as never) }
                            else {
                                AsyncStorage.setItem('@access_token', JSON.stringify(token)).then(() => {
                                    setSignedIn(true)
                                });
                            }
                        })
                })
                .catch((response) => {
                    if (response.status === 401) {
                        Alert.alert("Ошибка", "Неправильный логин или пароль", [
                            { text: "OK" }
                        ])
                    }else{
                        Alert.alert("Ошибка", response.status, [
                            { text: "OK" }
                        ])
                    }
                })
        }
    }

    const OnType = (value: string, property: string) => {
        setLoginModel(prevState => ({
            ...prevState,
            [property]: value,
        }));
    };

    return (
        <SafeAreaView style={styles.main}>
            <Image source={logoImg} style={{ width: 150, height: 150, marginVertical: 100 }} />
            <View>
                <Input placeholderText="Имя пользователя" propertyName="username" onTypeText={OnType} multiline={false} secureTextEntry={false} />
                <Input placeholderText="Пароль" propertyName="password" onTypeText={OnType} multiline={false} secureTextEntry />
                <Button text="Войти" onClick={onLoginClick} />
            </View>
        </SafeAreaView>
    )
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        // justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: backgroundColor
    },

    inputStyle: {
        backgroundColor: '#383838',
        width: windowWidth / 1.2,
        color: 'white',
        borderRadius: 10
    }
})