import React, { useEffect } from "react";
import { StyleSheet, Text, View } from "react-native";
import { whiteColor, windowWidth } from "../../../../_helpers/constant";

export default function Calendar({ activePage }: { activePage: number }) {

    useEffect(() => {
        if (activePage == 1) {
            console.log(activePage)
        }
    }, [activePage])

    return (
        <View style={styles.page}>
            <Text style={{ color: "white" }}>Calendar</Text>
        </View>
    );
}

const styles = StyleSheet.create({
    page: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        width: windowWidth
    },
});