import React, { useState } from "react";
import { SafeAreaView, StyleSheet, View } from "react-native";
import { backgroundColor, windowWidth, blackColor, ServerUrl } from "../../../_helpers/constant";
import Input from "../../../_helpers/components/InputComponent";
import Button from "../../../_helpers/components/ButtonComponent";
import { Alert } from "react-native";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useNavigation } from "@react-navigation/native";

export default function ChangePassword() {
    const navigation = useNavigation()

    const [passwordModel, setPasswordModel] = useState({
        oldPassword: "",
        newPassword: "",
        confirmPassword: ""
    })

    const OnType = (value: string, property: string) => {
        setPasswordModel(prevState => ({
            ...prevState,
            [property]: value,
        }));
    };

    const getToken = async () => {
        const value = await AsyncStorage.getItem('@access_token');
        return value != null ? JSON.parse(value) : null;
    }

    const OnPressChange = async () => {
        if (passwordModel.oldPassword !== '' && passwordModel.newPassword !== '' && passwordModel.confirmPassword !== '') {
            if (passwordModel.newPassword === passwordModel.confirmPassword) {
                let access_token = await getToken()
                const options = {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                        Authorization: "Bearer " + access_token,
                    },
                    body: JSON.stringify(passwordModel)
                }
                let url = ServerUrl + '/api/Users/changePassword';
                await fetch(url, options)
                    .then(() => {
                        navigation.navigate("SettingsScreen" as never)
                    })
            } else {
                Alert.alert('Поля не соответствуют', 'Пожалуйста, убедитесь что поля Новый пароль и Подтвердите пароль соответствуют.', [
                    { text: 'OK', onPress: () => null },
                ])
            }
        } else {
            console.log(passwordModel)
            Alert.alert('Заполните все поля', 'Пожалуйста, заполните все поля чтобы сменить пароль.', [
                { text: 'OK', onPress: () => null },
            ])
        }
    }

    return (
        <SafeAreaView style={styles.main}>
            <View style={styles.view}>
                <Input propertyName={'oldPassword'} onTypeText={OnType} placeholderText={'Старый пароль'} multiline={false} secureTextEntry />
                <Input propertyName={'newPassword'} onTypeText={OnType} placeholderText={'Новый пароль'} multiline={false} secureTextEntry />
                <Input propertyName={'confirmPassword'} onTypeText={OnType} placeholderText={'Подтвердите пароль'} multiline={false} secureTextEntry />
                <Button text={'Изменить'} onClick={OnPressChange} />
            </View>
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
        justifyContent: 'center',
        alignItems: 'center'
    }
})