import React, { useEffect, useState } from "react";
import { Image, Modal, RefreshControl, ScrollView, StyleSheet, Text, TouchableOpacity, TouchableWithoutFeedback, View } from "react-native";
import { ServerUrl, backgroundColor, inputFieldColor, secondColor, userID, whiteColor, windowWidth } from "../../../_helpers/constant";
import AsyncStorage from "@react-native-async-storage/async-storage";
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';
import { useIsFocused, useNavigation } from "@react-navigation/native";
import Permissions from 'react-native-permissions';
import * as ImagePicker from 'react-native-image-picker';
import TopTabNavigator from "./Components/TopTabNavigator";
import { useAtom } from "jotai";

interface User {
    id: string,
    email: string,
    username: string,
    firstName: string,
    lastName: string,
    userRoles: {
        role: Role
    }[],
    toDoList: Todo[],
    file: UserImage
}

interface Role {
    id: string,
    name: string,
    parentRole: Role,
    department: Department
}

interface Department {
    id: string,
    name: string
}

interface Todo {
    id: string,
    dateCreated: Date,
    startDate: Date,
    endDate: Date,
    completeDate: Date,
    status: number
}

interface UserImage {
    fileBase64: string,
    fileExtension: string,
    name: string
}

const profileImage = require('./../../../public/img/profile.png')

export default function Profile() {
    const navigation = useNavigation()
    const isFocused = useIsFocused()
    const [user, setUser] = useState<User>();
    const [todos, setTodos] = useState<Todo[]>([]);
    const [refreshing, setRefreshing] = useState(false);
    const [modalVisible, setModalVisible] = useState(false);
    const [imageChanged, setImageChanged] = useState(false);
    const [userId, setUserId] = useAtom(userID);

    const cameraOptions : ImagePicker.CameraOptions = {
        mediaType: 'photo',
        quality: 1,
        cameraType: 'back',
        saveToPhotos: true,
        includeBase64: true,
        maxWidth: windowWidth,
        maxHeight: windowWidth
    }

    const imageLibraryptions : ImagePicker.ImageLibraryOptions = {
        selectionLimit: 1,
        mediaType: 'photo',
        includeBase64: true,
        quality: 1,
    };

    useEffect(() => {
        if (isFocused) {
            getUserData()
        }
    }, [isFocused, imageChanged])

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
                setUser(response)
                setUserId(response.id)
            })
    }

    const openCamera = () => {
        Permissions.check('android.permission.CAMERA').then(async (response) => {
            if (response === 'granted') {
                var result = await ImagePicker.launchCamera(cameraOptions)
                if (!result.didCancel) {
                    if (result.assets != null) ChangeUserImage(result.assets[0])
                }
            } else {
                Permissions.request('android.permission.CAMERA').then(async (response) => {
                    if (response === 'granted') {
                        var result = await ImagePicker.launchCamera(cameraOptions)
                        if (!result.didCancel) {
                            if (result.assets != null) ChangeUserImage(result.assets[0])
                        }
                    }
                });
            }
        });
        setModalVisible(false)
    }

    const openGallery = () => {
        Permissions.check('android.permission.READ_MEDIA_IMAGES').then(async (response) => {
            if (response === 'granted') {
                var result = await ImagePicker.launchImageLibrary(imageLibraryptions)
                if (!result.didCancel){
                    if (result.assets != null) ChangeUserImage(result.assets[0])
                }
            } else {
                Permissions.request('android.permission.READ_MEDIA_IMAGES').then(async (response) => {
                    if (response === 'granted') {
                        var result = await ImagePicker.launchImageLibrary(imageLibraryptions)
                        if (!result.didCancel){
                            if (result.assets != null) ChangeUserImage(result.assets[0])
                        }
                    }
                });
            }
        });
    }

    const ChangeUserImage = async (result: ImagePicker.Asset) => {
        let access_token = await getToken()
        const options = {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            },
            body: JSON.stringify({
                fileBase64: result.base64,
                fileExtension: result.type?.replace("image/", ""),
                name: result.fileName
            })
        }
        let url = ServerUrl + '/api/Users/changeImage';
        await fetch(url, options)
            .then(() => {
                setImageChanged(!imageChanged)
                setModalVisible(false)
            })
    }

    const DeleteUserImage = async () => {
        let access_token = await getToken()
        const options = {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + access_token,
            }
        }
        let url = ServerUrl + '/api/Users/deleteUserImage';
        await fetch(url, options)
            .then(() => {
                setImageChanged(!imageChanged)
                setModalVisible(false)
            })
    }

    const onRefresh = React.useCallback(() => {
        getUserData()
    }, []);

    return (
        <ScrollView style={styles.main} refreshControl={<RefreshControl refreshing={refreshing} onRefresh={onRefresh} />}>
            <Modal
                animationType="slide"
                transparent={true}
                visible={modalVisible}
                onRequestClose={() => {
                    setModalVisible(false);
                }}
            >
                <TouchableWithoutFeedback onPress={() => setModalVisible(false)}>
                    <View style={styles.modalContainer}>
                        <View style={styles.modalContent}>
                            <TouchableOpacity onPress={() => openGallery()} style={styles.modalButton}>
                                <Icon name={"image"} color={'black'} size={30} />
                            </TouchableOpacity>
                            <TouchableOpacity onPress={() => openCamera()} style={styles.modalButton}>
                                <Icon name={"camera"} color={'black'} size={30} />
                            </TouchableOpacity>
                            <TouchableOpacity onPress={() => DeleteUserImage()} style={styles.modalButton}>
                                <Icon name={"delete"} color={'black'} size={30} />
                            </TouchableOpacity>
                        </View>
                    </View>
                </TouchableWithoutFeedback>
            </Modal>
            <View style={styles.profileView}>
                <View>
                    <TouchableOpacity onLongPress={() => setModalVisible(true)}>
                        <Image source={user?.file ? { uri: `data:image/${user.file.fileExtension};base64,` + user.file.fileBase64 } : profileImage} style={{ width: 120, height: 120, borderRadius: 120 / 2, borderWidth: 3, borderColor: whiteColor }} />
                    </TouchableOpacity>
                </View>
                <View style={styles.profileInfoView}>
                    <View>
                        <Text style={styles.userFullNameText}>{user?.firstName}</Text>
                        <Text style={styles.userFullNameText}>{user?.lastName}</Text>
                        {user?.userRoles.map(userRole =>
                            <Text key={userRole.role.id} style={[styles.userInfoText, { color: secondColor }]}>{userRole.role.name}</Text>
                        )}
                        <Text style={styles.userInfoText}>{user?.email}</Text>
                    </View>
                    <View>
                        <TouchableOpacity onPress={() => navigation.navigate("ProfileEdit" as never)}>
                            <Icon name={"pencil"} color={'white'} size={20} />
                        </TouchableOpacity>
                    </View>
                </View>
            </View>
            <View style={{ flex: 1 }}>
                <TopTabNavigator />
            </View>
        </ScrollView>
    )
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        backgroundColor: backgroundColor,
    },

    profileView: {
        backgroundColor: inputFieldColor,
        width: windowWidth - 20,
        padding: 20,
        borderRadius: 10,
        flexDirection: 'row',
        justifyContent: 'center',
        alignItems: 'center',
        marginHorizontal: 10
    },

    profileInfoView: {
        marginHorizontal: 20,
        flexDirection: 'row',
    },

    userFullNameText: {
        color: whiteColor,
        fontSize: 24,
        fontWeight: 'bold',
        textAlign: 'left',
    },

    userInfoText: {
        color: whiteColor
    },

    taskView: {
        backgroundColor: inputFieldColor,
        width: windowWidth - 20,
        padding: 20,
        borderRadius: 10,
        flexDirection: 'row',
        justifyContent: 'center',
        alignItems: 'center',
        marginVertical: 10,
    },

    modalContainer: {
        flex: 1,
        justifyContent: 'flex-end',
        backgroundColor: 'rgba(0, 0, 0, 0.5)',
    },
    modalContent: {
        backgroundColor: whiteColor,
        padding: 20,
        borderTopLeftRadius: 10,
        borderTopRightRadius: 10,
        alignItems: 'center',
        flexDirection: 'row',
        justifyContent: 'space-evenly'
    },
    modalButton: {
        alignItems: 'center',
        justifyContent: 'center'
    },

})
