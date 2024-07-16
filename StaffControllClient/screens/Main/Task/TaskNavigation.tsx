import { ScrollView, StyleSheet, TouchableOpacity, View } from "react-native";
import { backgroundColor, filterVisible, tabColor, whiteColor } from "../../../_helpers/constant";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';
import { useNavigation } from "@react-navigation/native";
import TaskScreen from "./TaskScreen";
import NewTaskScreen from "./NewTaskScreen";
import SelectDropdown from "react-native-select-dropdown";
import SelectedTaskScreen from "./SelectedTaskScreen";
import { useState } from "react";
import { useAtom } from "jotai";

export default function TaskNavigation() {
    const navigation = useNavigation()
    const Stack = createNativeStackNavigator()

    const [visible, setVisible] = useAtom(filterVisible)

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
            <Stack.Screen name="TaskScreen" component={TaskScreen} options={{
                headerTitle: "Задачи",
                headerRight: () => {
                    return (
                        <View style={styles.buttons}>
                            <TouchableOpacity onPress={() => setVisible(!visible)}>
                                <Icon name={'filter'} size={30} color={'white'} />
                            </TouchableOpacity>
                            <TouchableOpacity onPress={() => navigation.navigate('NewTaskScreen' as never)}>
                                <Icon name={'plus'} size={30} color={'white'} />
                            </TouchableOpacity>
                        </View>
                    )
                }
            }} />
            <Stack.Screen name="NewTaskScreen" component={NewTaskScreen} options={{ headerTitle: "Новая задача" }} />
            <Stack.Screen name="SelectedTaskScreen" component={SelectedTaskScreen} options={{ headerTitle: "Задача" }} />
        </Stack.Navigator>
    )
}

const styles = StyleSheet.create({
    buttons: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        width: 70
    },
})