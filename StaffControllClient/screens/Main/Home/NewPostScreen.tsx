import React, { useState } from "react";
import { Image, ImageBackground, ScrollView, StyleSheet, Text, TouchableOpacity, View } from "react-native";
import { ServerUrl, backgroundColor, inputFieldColor, whiteColor, windowWidth } from "../../../_helpers/constant";
import Input from "../../../_helpers/components/InputComponent";
import Permissions from 'react-native-permissions';
import * as ImagePicker from 'react-native-image-picker';
import Button from "../../../_helpers/components/ButtonComponent";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useNavigation } from "@react-navigation/native";

interface Post {
    title: string;
    description: string;
    files: File[];
}

interface File {
    fileExtension: string;
    fileBase64: string;
    name: string;
}

const imageLogo = require('./../../../public/img/imageLogo.png')

export default function NewPost() {
    const navigation = useNavigation()

    const [post, setPost] = useState<Post>({
        title: "",
        description: "",
        files: []
    });

    const imageLibraryOptions: ImagePicker.ImageLibraryOptions = {
        mediaType: 'photo',
        includeBase64: true,
        quality: 1,
        selectionLimit: 0
    };

    const openGallery = () => {
        Permissions.check('android.permission.READ_MEDIA_IMAGES').then(async (response) => {
            if (response === 'granted') {
                var result = await ImagePicker.launchImageLibrary(imageLibraryOptions)
                if (!result.didCancel) {
                    if (result.assets != null) AddImageToPost(result.assets)
                }
            } else {
                Permissions.request('android.permission.READ_MEDIA_IMAGES').then(async (response) => {
                    if (response === 'granted') {
                        var result = await ImagePicker.launchImageLibrary(imageLibraryOptions)
                        if (!result.didCancel) {
                            if (result.assets != null) AddImageToPost(result.assets)
                        }
                    }
                });
            }
        });
    }

    const AddImageToPost = async (assets: ImagePicker.Asset[]) => {
        const newFiles = [...post.files];

        for (let i = 0; i < assets.length; i++) {
            // Создаем объект файла для каждого актива изображения
            const asset: File = {
                fileExtension: assets[i].type?.replace("image/", "") as string,
                fileBase64: assets[i].base64 as string,
                name: assets[i].fileName as string,
            };
            // Добавляем созданный файл к массиву новых файлов
            newFiles.push(asset);
        }

        // Обновляем состояние post, включая новые файлы
        setPost(prevPost => ({
            ...prevPost,
            files: newFiles
        }));
    }

    const getToken = async () => {
        const value = await AsyncStorage.getItem('@access_token');
        return value != null ? JSON.parse(value) : null;
    }

    const AddNewPost = async () => {
        let access_token = await getToken()
        const options = {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            },
            body: JSON.stringify(post)
        }
        let url = ServerUrl + '/api/News/create';
        await fetch(url, options)
            .then(() => navigation.navigate("Home" as never))
    }

    const OnType = (value: string, property: string) => {
        setPost(prevState => ({
            ...prevState,
            [property]: value.trim(),
        }));
        console.log(post)
    };

    return (
        <ScrollView style={styles.main}>
            <View style={styles.inputFieldView}>
                <Text style={{ color: whiteColor }}>
                    Заголовок
                </Text>
                <Input placeholderText={"Заголовок"} propertyName="title" onTypeText={OnType} multiline={false} />
            </View>
            <View style={styles.inputFieldView}>
                <Text style={{ color: whiteColor }}>
                    Описание
                </Text>
                <Input placeholderText={"Описание"} propertyName="description" onTypeText={OnType} multiline={true} />
            </View>
            <View>
                <ScrollView
                    horizontal
                    pagingEnabled
                    style={styles.scrollView}
                    showsHorizontalScrollIndicator={false}>

                    {post.files.map((image, index) =>
                        <Image key={index} source={{ uri: `data:image/${image.fileExtension};base64,` + image.fileBase64 }} style={styles.imageView} />
                    )}

                    <TouchableOpacity
                        style={[styles.imageView, {
                            borderRadius: 10,
                            borderWidth: 5,
                            borderStyle: 'dashed',
                            borderColor: 'grey'
                        }]}
                        onPress={() => openGallery()}
                    >
                        <Text style={{ color: 'white', textAlign: 'center' }}>Добавить фото/видео</Text>
                    </TouchableOpacity>
                </ScrollView>
                <View style={styles.inputFieldView}>
                    <Button text="Добавить" onClick={() => AddNewPost()} />
                </View>
            </View>
        </ScrollView>
    )
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        backgroundColor: backgroundColor,
        paddingVertical: 10
    },

    inputFieldView: {
        marginHorizontal: 10,
        alignItems: 'center',
        width: windowWidth - 20,
        marginBottom: 10,
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
    }
})