import { useNavigation } from "@react-navigation/native";
import React, { useEffect, useState } from "react";
import { View, Text, StyleSheet, TextInput, SafeAreaView, TouchableOpacity, Alert } from "react-native";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useAtom } from "jotai";
import { signed, token, ServerUrl, whiteColor, backgroundColor, inputFieldColor } from "../../../_helpers/constant";
import Button from "../../../_helpers/components/ButtonComponent";

export default function TwoFactorScreen() {
    const navigation = useNavigation()
    const [code, setCode] = useState<string>();

    const getToken = async () => {
        const value = await AsyncStorage.getItem('@access_token');
        return value != null ? JSON.parse(value) : null;
    }

    const SendCode = async () => {
        let access_token = await getToken()
        const options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            }
        }
        let url = ServerUrl + '/api/Users/sendCode';
        await fetch(url, options)
    }

    const VerifyCode = async () => {
        let access_token = await getToken()
        console.log(access_token)
        const options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            }
        }
        let url = ServerUrl + '/api/Users/enableOrDisable2FA?code=' + code;
        await fetch(url, options)
            .then((response) => {
                console.log(response)
                if (response.status === 200){
                    navigation.navigate('SettingsScreen' as never)
                }else{
                    Alert.alert('Неправильный код аутентификации', 'Пожалуйста, убедитесь что написали код аутентификации правильно.', [
                        { text: 'OK', onPress: () => null },
                    ])
                }
            })
    }

    return (
        <SafeAreaView style={styles.main}>
            <TextInput
                style={styles.inputField}
                placeholder={'0000'}
                placeholderTextColor={'#a1a1a1'}
                onChangeText={(e) => setCode(e)}
                maxLength={4}
            />
            <TouchableOpacity style={styles.sendCode} onPress={SendCode}>
                <Text style={{color: whiteColor}}>Отправить код</Text>
            </TouchableOpacity>
            <Button text='Подтвердить' onClick={VerifyCode}/>
        </SafeAreaView>
    )
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        backgroundColor: backgroundColor,
        // justifyContent: 'center',
        alignItems: 'center'
    },
    
    inputField: {
        marginTop: 30,
        width: 100,
        paddingHorizontal: 10,
        marginVertical: 5,
        color: whiteColor,
        backgroundColor: inputFieldColor,
        borderRadius: 10,
        fontSize: 30,
        fontWeight: 'bold',
        textAlign: 'center'
    },

    sendCode: {
        marginVertical: 10,
        marginBottom: 30
    }
});