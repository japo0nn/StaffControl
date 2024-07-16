import React, { useEffect, useState } from "react";
import { ActivityIndicator, Image, RefreshControl, ScrollView, StyleSheet, Text, TouchableOpacity, View } from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";
import { ServerUrl, backgroundColor, inputFieldColor, userID, whiteColor, windowWidth } from "../../../_helpers/constant";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useAtom } from "jotai";
import { useIsFocused, useNavigation } from "@react-navigation/native";

const profileImage = require('./../../../public/img/profile.png')

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
    files: File[],
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

export default function Home(){
    const isFocused = useIsFocused()
    const navigation = useNavigation()

    const [pageNumber, setPageNumber] = useState<number>(1)
    const [pageDto, setPageDto] = useState<PageDto>();
    const [loading, setLoading] = useState(true)
    const [refreshing, setRefreshing] = useState(false);

    useEffect(() => {
        if (isFocused) {
            GetPosts()
        }
    }, [isFocused])

    const getToken = async () => {
        const value = await AsyncStorage.getItem('@access_token');
        return value != null ? JSON.parse(value) : null;
    }

    const GetPosts = async () => {
        setLoading(true)
        let access_token = await getToken()
        const options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            }
        }
        let url = ServerUrl + `/api/News/getNewsList?page=${pageNumber}`;
        console.log(url)
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

    const onRefresh = React.useCallback(() => {
        GetPosts()
    }, []);

    return(
        <ScrollView style={styles.main} refreshControl={<RefreshControl refreshing={refreshing} onRefresh={onRefresh} />}>
            {loading ? (
                <View style={{flex: 1, alignItems: 'center', justifyContent: 'center'}}>
                    <ActivityIndicator size={'large'} style={{ flex: 1, alignSelf: 'center' }} color={'white'}/>
                </View>
            ) : (
                pageDto?.items?.map(post =>
                    <View key={post.id} style={styles.postView}>
                        <View style={styles.userInfoView}>
                            <Image source={post.user?.file ? { uri: `data:image/${post.user.file.fileExtension};base64,` + post.user.file.fileBase64 } : profileImage} style={{width: 30, height: 30, borderRadius: 15}}/>
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
        </ScrollView>
    )
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        backgroundColor: backgroundColor,
    },

    postView: {
        width: windowWidth,
        paddingVertical: 10,
        backgroundColor: 'black',
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
        paddingVertical: 10,
        alignItems: 'center'
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
})