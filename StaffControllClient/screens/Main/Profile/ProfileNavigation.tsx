import { createNativeStackNavigator } from "@react-navigation/native-stack";
import React, { useState } from "react";
import Profile from "./ProfileScreen";
import { signed, tabColor, whiteColor } from "../../../_helpers/constant";
import ProfileEdit from "./ProfileEditScreen";
import NewPost from "../Home/NewPostScreen";
import { Settings, TouchableOpacity, View } from "react-native";
import { useAtom } from "jotai";
import Icon from 'react-native-vector-icons/MaterialIcons';
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useNavigation } from "@react-navigation/native";
import SettingsScreen from "./SettingsScreen";
import ChangePassword from "./ChangePasswordScreen";
import TwoFactorScreen from "./TwoFactorVerifyScreen";
import AddUserScreen from "./AddUserScreen";

export default function ProfileNavigation() {
    const Stack = createNativeStackNavigator();
    const navigation = useNavigation()

    const [signedIn, setSignedIn] = useAtom(signed)

    return (
        <Stack.Navigator
            screenOptions={{
                headerStyle: {
                    backgroundColor: tabColor,
                },
                headerTitleStyle: {
                    color: whiteColor
                }
            }}>
            <Stack.Group>
                <Stack.Screen name="Profile" component={Profile} options={{
                    title: 'Профиль',
                    headerRight: () => {
                        return (
                            <TouchableOpacity onPress={() => navigation.navigate('SettingsScreen' as never)}>
                                <Icon name={'settings'} size={30} color={'white'} />
                            </TouchableOpacity>
                        )
                    }
                }} />
                <Stack.Screen name="ProfileEdit" component={ProfileEdit} options={{ title: 'Редактировать профиль' }} />
                <Stack.Screen name="NewPost" component={NewPost} options={{ headerTitle: "Новая запись" }} />
                <Stack.Screen name="SettingsScreen" component={SettingsScreen} options={{ headerTitle: "Настройки" }} />
                <Stack.Screen name="ChangePassword" component={ChangePassword} options={{ headerTitle: "Смена пароля" }} />
                <Stack.Screen name="AddUserScreen" component={AddUserScreen} options={{ headerTitle: "Добавить пользователя" }} />
            </Stack.Group>
            <Stack.Group screenOptions={{presentation: 'modal'}}>
                <Stack.Screen name="TwoFactorScreen" component={TwoFactorScreen} options={{ headerTitle: "2FA" }} />
            </Stack.Group>
        </Stack.Navigator>
    )
}