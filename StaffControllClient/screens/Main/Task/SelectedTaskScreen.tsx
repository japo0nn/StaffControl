import React, { useEffect, useState } from "react";
import { StyleSheet, Text, View, ScrollView, Image } from "react-native";
import { ServerUrl, backgroundColor, blackColor, selectedTask, userID, whiteColor } from "../../../_helpers/constant";
import { useIsFocused, useNavigation } from "@react-navigation/native";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useAtom } from "jotai";
import Button from "../../../_helpers/components/ButtonComponent";

interface Task {
    id: string,
    dateCreated: string,
    startDate: string,
    endDate: string,
    status: number,
    author: User,
    responsible: User,
    name: string,
    description: string,
}

interface User {
    id: string;
    firstName: string;
    lastName: string;
    file: File;
    userRoles: {
        role: Role
    }[],
}

interface Role {
    id: string,
    name: string,
    parentRole: Role,
}

interface File {
    fileExtension: string;
    fileBase64: string;
}

const profileImage = require('./../../../public/img/profile.png')

export default function SelectedTaskScreen() {
    const isFocused = useIsFocused()

    const [selectedTaskId, setSelectedTaskId] = useAtom(selectedTask)
    const [userId, setUserId] = useAtom(userID)
    const [todo, setTodo] = useState<Task>()
    const [loading, setLoading] = useState(true)

    useEffect(() => {
        if (isFocused) {
            getUserData()
            GetTaskById()
        }
    }, [isFocused])

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
                setUserId(response.id)
            })
    }

    const GetTaskById = async () => {
        setLoading(true)
        let access_token = await getToken()
        const options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            }
        }
        let url = ServerUrl + `/api/ToDoes/getTaskById?todoId=${selectedTaskId}`;
        await fetch(url, options)
            .then((response) => response.json())
            .then((response) => {
                setTodo(response)
                console.log(response)
                console.log(userId)
                setLoading(false)
            })
    }

    const UpdateStatus = async(status : number) => {
        let access_token = await getToken()
        const options = {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            }
        }
        let endpoint = '/api/ToDoes/updateStatus'
        let url = ServerUrl + `${endpoint}?todoId=${selectedTaskId}&status=${status}`;
        console.log(url)
        await fetch(url, options)
            .then(() => GetTaskById())
    }

    return (
        <ScrollView style={styles.main}>
            <View style={styles.todoView}>
                <Text style={styles.todoName}>{todo?.name}</Text>
                <View style={styles.infoView}>
                    <Text style={styles.todoDescription}>Описание: {todo?.description}</Text>
                </View>
                <View style={styles.infoView}>
                    <Text style={styles.todoDescription}>Статус:
                        {todo?.status === 0 ? " В ожидании" : (
                            todo?.status === 1 ? " В работе" : (
                                todo?.status === 2 ? " На рассмотрении" : (
                                    todo?.status === 3 ? " Отменено" : " Завершено"
                                )
                            )
                        )}
                    </Text>
                </View>
                <View style={styles.infoView}>
                    <Text style={styles.todoDescription}>Дата назначения: {new Date(todo?.startDate as string).toLocaleDateString('ru-RU')}</Text>
                </View>
                <View style={styles.infoView}>
                    <Text style={styles.todoDescription}>Срок задачи: {new Date(todo?.endDate as string).toLocaleDateString('ru-RU')}</Text>
                </View>
                <View style={styles.infoView}>
                    <Text style={styles.todoDescription}>Автор:</Text>
                    <View style={{ flexDirection: 'row', alignItems: 'center', marginVertical: 5 }}>
                        <Image source={todo?.author?.file ? { uri: `data:image/${todo.author?.file.fileExtension};base64,` + todo.author?.file.fileBase64 } : profileImage} style={{ width: 30, height: 30, borderRadius: 30 / 2 }} />
                        <Text style={styles.todoAuthor}>{todo?.author.firstName} {todo?.author.lastName}</Text>
                    </View>
                </View>
                <View style={styles.infoView}>
                    <Text style={styles.todoDescription}>Исполнитель:</Text>
                    <View style={{ flexDirection: 'row', alignItems: 'center', marginVertical: 5 }}>
                        <Image source={todo?.responsible?.file ? { uri: `data:image/${todo.responsible?.file.fileExtension};base64,` + todo.responsible?.file.fileBase64 } : profileImage} style={{ width: 30, height: 30, borderRadius: 30 / 2 }} />
                        <Text style={styles.todoAuthor}>{todo?.responsible.firstName} {todo?.responsible.lastName}</Text>
                    </View>
                </View>
                { (todo?.status !== 3 && todo?.status !== 4 && todo?.status !== 2 && todo?.responsible.id === userId)? (
                <View style={styles.infoView}>
                    <View style={{ alignItems: 'center', marginVertical: 5 }}>
                        <Button onClick={() => UpdateStatus(todo?.status + 1)} text={
                            todo?.status === 0 ? ("Начать задачу") : ("Отправить на рассмотрение")
                        } />
                    </View>
                </View>) : null}
                { (todo?.author.id == userId && todo?.status === 2) ? (
                <View style={styles.infoView}>
                    <View style={{ alignItems: 'center', marginVertical: 5, justifyContent: 'center' }}>
                        <Button onClick={() => UpdateStatus(4)} text={"Завершить задачу"} />
                    </View>
                </View>) : null}
                { (todo?.author.id == userId && todo?.status !== 3 && todo?.status !== 4) ? (
                <View style={styles.infoView}>
                    <View style={{ alignItems: 'center', marginVertical: 5, justifyContent: 'center' }}>
                        <Button onClick={() => UpdateStatus(3)} text={"Отменить задачу"} />
                    </View>
                </View>) : null}
            </View>
        </ScrollView>
    )
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        backgroundColor: backgroundColor
    },

    todoView: {
        paddingHorizontal: 10,
        paddingVertical: 10
    },

    todoName: {
        color: whiteColor,
        fontSize: 18,
        fontWeight: 'bold'
    },

    todoAuthor: {
        color: whiteColor,
        paddingHorizontal: 10
    },

    todoDescription: {
        color: whiteColor,
        fontSize: 16
    },

    infoView: {
        marginVertical: 5,
        justifyContent: 'center'
    }
})