import { BottomTabNavigationOptions, createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import React from "react";
import HomeNavigation from "./Home/HomeNavigation";
import { tabColor, whiteColor } from "../../_helpers/constant";
import ProfileNavigation from "./Profile/ProfileNavigation";
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';
import TaskNavigation from "./Task/TaskNavigation";

export default function MainNavigator() {
    const Tab = createBottomTabNavigator();

    return (
        <Tab.Navigator
            detachInactiveScreens={false}
            screenOptions={({ route, navigation }): BottomTabNavigationOptions => ({
                headerShown: false,
                tabBarStyle: {
                    backgroundColor: tabColor,
                    borderWidth: 0,
                    borderTopWidth: 0
                },
                tabBarActiveTintColor: whiteColor,
                tabBarIcon: ({ focused, color, size }) => {
                    let iconName;
                    if (route.name === 'HomeNavigation') {
                        iconName = focused ? 'home' : 'home-outline';
                    } else if (route.name === 'ProfileNavigation') {
                        iconName = focused ? 'account' : 'account-outline';
                    } else if (route.name === "TaskNavigation") {
                        iconName = focused ? 'note-edit' : 'note-edit-outline';
                    }
                    return <Icon name={iconName as string} size={size} color={color} />;
                },
                
            })}>
            <Tab.Screen component={HomeNavigation} name="HomeNavigation" options={{ title: 'Главная' }} />
            <Tab.Screen component={TaskNavigation} name="TaskNavigation" options={{ title: 'Задачи' }} />
            <Tab.Screen component={ProfileNavigation} name="ProfileNavigation" options={{ title: 'Профиль' }} />
        </Tab.Navigator>
    )
}