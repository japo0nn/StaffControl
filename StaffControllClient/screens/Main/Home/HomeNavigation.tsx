import { createNativeStackNavigator } from "@react-navigation/native-stack";
import React from "react";
import Home from "./HomeScreen";
import { tabColor, whiteColor } from "../../../_helpers/constant";
import NewPost from "./NewPostScreen";
import { TouchableOpacity, View } from "react-native";
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';
import { useNavigation } from "@react-navigation/native";

export default function HomeNavigation() {
    const navigation = useNavigation()
    const Stack = createNativeStackNavigator();

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
            <Stack.Screen name="Home" component={Home} options={{ headerTitle: "Главная",
                headerRight: () => {
                    return(
                        <TouchableOpacity onPress={() => navigation.navigate('NewPost' as never)}>
                            <Icon name={'plus'} size={30} color={'white'}/>
                        </TouchableOpacity>
                    )
                }
             }} />
            <Stack.Screen name="NewPost" component={NewPost} options={{ headerTitle: "Новая запись" }} />
        </Stack.Navigator>
    )
}