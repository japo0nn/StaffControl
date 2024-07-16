import React, { useEffect, useState } from "react";
import { ActivityIndicator, Image, Pressable, ScrollView, StyleSheet, Text, TouchableOpacity, View } from "react-native";
import { ServerUrl, userID, whiteColor, windowWidth } from "../../../../_helpers/constant";
import { useAtom } from "jotai";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useNavigation } from "@react-navigation/native";

const profileImage = require('./../../../../public/img/profile.png')

interface PageDto {
    items: Post[];
    pageViewModel: {
        pageNumber: number;
        totalPages: number;
        hasPreviousPage: boolean;
        hasNextPage: boolean
    }
}

interface Post {
    id: string;
    title: string;
    description: string;
    user: User;
    files: File[]
    dateCreated: Date
}

interface User {
    id: string;
    firstName: string;
    lastName: string;
    file: File
}

interface File {
    fileExtension: string;
    fileBase64: string;
}

export default function Post({ activePage }: { activePage: number }) {
    const navigation = useNavigation()

    const [userId, setUserId] = useAtom(userID)
    const [pageNumber, setPageNumber] = useState<number>(1)
    const [pageDto, setPageDto] = useState<PageDto>();
    const [loading, setLoading] = useState(true)

    useEffect(() => {
        if (activePage == 0) {
            GetPostsByUserId()
        }
    }, [activePage])

    const getToken = async () => {
        const value = await AsyncStorage.getItem('@access_token');
        return value != null ? JSON.parse(value) : null;
    }

    const GetPostsByUserId = async () => {
        setLoading(true)
        let access_token = await getToken()
        const options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            }
        }
        let url = ServerUrl + `/api/News/getPostsByUserId?userId=${userId}&page=${pageNumber}`;
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
            <View style={styles.newPostView}>
                <TouchableOpacity onPress={() => navigation.navigate("NewPost" as never)} style={styles.newPostBtn}>
                    <Text style={styles.newPostText}>+ Новая запись</Text>
                </TouchableOpacity>
            </View>
            {loading ? (
                <ActivityIndicator size={'large'} style={{ flex: 1 }} />
            ) : (
                pageDto?.items?.map(post =>
                    <View key={post.id} style={styles.postView}>
                        <View style={styles.userInfoView}>
                            <Image source={post.user?.file ? { uri: `data:image/${post.user.file.fileExtension};base64,` + post.user.file.fileBase64 } : profileImage} style={{width: 30, height: 30}}/>
                            <Text style={{color: whiteColor, marginLeft: 5}}>{post.user.firstName} {post.user.lastName}</Text>
                        </View>
                        <Text style={styles.postTitle}>{post.title}</Text>
                        <Text style={styles.postDescription}>{post.description}</Text>
                        <ScrollView
                            horizontal
                            pagingEnabled
                            style={styles.scrollView}
                            showsHorizontalScrollIndicator={false}>

                            {post.files.map((image, index) =>
                                <Image key={index} source={{ uri: `data:image/${image.fileExtension};base64,` + image.fileBase64 }} style={styles.imageView} />
                            )}
                        </ScrollView>
                        <Text style={{color: whiteColor, fontSize: 14, marginTop: 5, textAlign: 'right'}}>{new Date(post.dateCreated).toLocaleDateString()}</Text>
                    </View>
                ))}
        </View>
    )
}

const styles = StyleSheet.create({
    page: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        width: windowWidth
    },

    postView: {
        width: windowWidth,
        paddingVertical: 10,
        marginVertical: 5
    },

    postTitle: {
        color: whiteColor,
        fontWeight: 'bold',
        fontSize: 20,
        paddingHorizontal: 10
    },

    postDescription: {
        color: whiteColor,
        paddingHorizontal: 10,
        marginBottom: 5
    },

    newPostView: {
        paddingHorizontal: 10,
        paddingVertical: 10
    },

    newPostBtn: {
        borderColor: whiteColor,
        width: windowWidth - 40,
        borderWidth: 3,
        paddingHorizontal: 20,
        paddingVertical: 10,
        borderRadius: 10
    },

    newPostText: {
        color: whiteColor,
        fontSize: 16,
        textAlign: 'center',
    },

    scrollView: {
        flex: 1,
    },

    imageView: {
        flex: 1,
        width: windowWidth,
        height: windowWidth,
        paddingVertical: 10,
        justifyContent: 'center',
        alignItems: 'center',
    },

    userInfoView: {
        flexDirection: 'row',
        paddingHorizontal: 10,
        alignItems: 'center'
    }
});