import React, { useEffect, useState } from "react";
import { ActivityIndicator, Image, ScrollView, StyleSheet, Text, TouchableOpacity, View } from "react-native";
import { ServerUrl, selectedTask, userID, whiteColor, windowWidth } from "../../../../_helpers/constant";
import { useAtom } from "jotai";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useNavigation } from "@react-navigation/native";

interface PageDto {
    items: Task[];
    pageViewModel: {
        pageNumber: number;
        totalPages: number;
        hasPreviousPage: boolean;
        hasNextPage: boolean
    }
}

interface Task {
    id: string,
    dateCreated: Date,
    startDate: Date,
    endDate: Date,
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

const profileImage = require('./../../../../public/img/profile.png')

export default function Todos({ activePage }: { activePage: number }) {
    const navigation = useNavigation();

    const [userId, setUserId] = useAtom(userID)
    const [loading, setLoading] = useState(true);
    const [pageNumber, setPageNumber] = useState<number>(1);
    const [pageDto, setPageDto] = useState<PageDto>();
    const [selectedTaskId, setSelectedTaskId] = useAtom(selectedTask)

    useEffect(() => {
        if (activePage == 1) {
            GetUserTasks()
        }
    }, [activePage])

    const getToken = async () => {
        const value = await AsyncStorage.getItem('@access_token');
        return value != null ? JSON.parse(value) : null;
    }

    const GetUserTasks = async () => {
        setLoading(true)
        let access_token = await getToken()
        const options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            },
        }
        let url = ServerUrl + `/api/ToDoes/getTasksByUserId?userId=${userId}&page=${pageNumber}`;
        await fetch(url, options)
            .then((response) => response.json())
            .then((response) => {
                setPageDto(response)
                setLoading(false)
                if (response.pageViewModel.hasNextPage) {
                    setPageNumber(pageNumber + 1)
                }
            })
    }

    return (
        <View style={styles.page}>
            {loading ? (
                <ActivityIndicator size={'large'} style={{ flex: 1 }} />
            ) : (
                pageDto?.items?.map(item =>
                    <TouchableOpacity key={item.id} style={styles.taskView} onPress={() => {
                        setSelectedTaskId(item.id)
                        navigation.navigate('TaskNavigation', { screen: 'SelectedTaskScreen' });
                    }}>
                        <Text style={{ color: whiteColor, fontWeight: 'bold', fontSize: 20 }}>{item.name}</Text>
                        <Text style={{ color: whiteColor, fontSize: 16, marginVertical: 5 }}>Статус:
                            {item?.status === 0 ? " В ожидании" : (
                                item?.status === 1 ? " В работе" : (
                                    item?.status === 2 ? " На рассмотрении" : (
                                        item?.status === 3 ? " Отменено" : " Завершено"
                                    )
                                )
                            )}
                        </Text>
                        <View style={styles.taskAuthorView}>
                            <Image source={item.author?.file ? { uri: `data:image/${item.author.file.fileExtension};base64,` + item.author.file.fileBase64 } : profileImage} style={{ width: 30, height: 30, borderRadius: 15 }} />
                            <Text style={{ color: whiteColor, marginHorizontal: 5 }}>{item.author.firstName} {item.author.lastName}</Text>
                        </View>
                    </TouchableOpacity>
                ))}
        </View>
    );
}

const styles = StyleSheet.create({
    page: {
        flex: 1,
        // justifyContent: 'center',
        // alignItems: 'center',
        width: windowWidth
    },

    taskView: {
        padding: 10,
    },

    taskAuthorView: {
        flexDirection: 'row',
        alignItems: 'center',
    }
});