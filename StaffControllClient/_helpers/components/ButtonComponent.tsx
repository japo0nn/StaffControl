import React from "react";
import { StyleSheet, Text, TouchableOpacity } from "react-native";
import { blackColor, mainColor, windowWidth } from "../constant";

interface ButtonProps {
    text: string;
    onClick: () => void;
}

export default function Button({ text, onClick }: ButtonProps) : JSX.Element{
    return(
        <TouchableOpacity  onPress={onClick} style={styles.btnContainer}>
            <Text style={styles.btnText}>{text}</Text>
        </TouchableOpacity >
    )
}

const styles = StyleSheet.create({
    btnContainer: {
        marginTop: 20,
        width: windowWidth - 40,
        height: 50,
        backgroundColor: mainColor,
        borderRadius: 10,
        alignItems: 'center',
        justifyContent: 'center'
    },

    btnText: {
        color: blackColor,
        fontSize: 20
    }
})