import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import React, { useEffect } from "react";
import Auth from "../screens/LoginScreen";
import { ServerUrl, admin, signed, tabColor, userID } from "./constant";
import { useAtom } from "jotai";
import AsyncStorage from "@react-native-async-storage/async-storage";
import MainNavigator from "../screens/Main/MainNavigation";
import { StatusBar } from "react-native";
import changeNavigationBarColor from "react-native-navigation-bar-color";
import TwoFactorScreen from "../screens/TwoFactorVerifyScreen";

export default function Navigation() {
    const [signedIn, setSignedIn] = useAtom(signed);
    const [userId, setUserId] = useAtom(userID)
    const [isAdmin, setIsAdmin] = useAtom(admin)
    const Stack = createNativeStackNavigator();
    useEffect(() => {
        changeNavigationBarColor(tabColor, false)
        getData()
    }, [])

    const getToken = async () => {
        const value = await AsyncStorage.getItem('@access_token');
        return value != null ? JSON.parse(value) : null;
    }

    const getData = async () => {
        let access_token = await getToken()
        if (access_token != null) {
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
                    if (response !== undefined) {
                        setUserId(response.id)
                        if (response.userRoles[0].role.name === 'Системный администратор') setIsAdmin(true)
                        setSignedIn(true)
                    }
                })
        }
    }
    return (
        <>
            <StatusBar barStyle={'light-content'} backgroundColor={tabColor} />
            <NavigationContainer>
                <Stack.Navigator screenOptions={{ headerShown: false }}>
                    {signedIn ? (
                        <Stack.Screen
                            name="MainNavigator"
                            component={MainNavigator}
                            options={{
                                headerShown: false,
                            }}
                        />
                    ) : (
                        <Stack.Group>
                            <Stack.Screen
                                name="Auth"
                                component={Auth}
                                options={{
                                    headerShown: false,
                                }}
                            />
                            <Stack.Screen
                                name="LoginTwoFactorScreen"
                                component={TwoFactorScreen}
                                options={{
                                    headerShown: false,
                                }}
                            />
                        </Stack.Group>
                    )}
                </Stack.Navigator>
            </NavigationContainer>
        </>
    )
}