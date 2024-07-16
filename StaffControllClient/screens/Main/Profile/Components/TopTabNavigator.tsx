import React, { useRef, useState } from 'react';
import { ScrollView, View, Text, StyleSheet, Pressable } from 'react-native';
import { inputFieldColor, whiteColor, windowWidth } from '../../../../_helpers/constant';
import Post from './PostComponent';
import Calendar from './CalendarComponent';
import Todos from './TodosComponent';

const TopTabNavigator: React.FC = () => {
    const [activePage, setActivePage] = useState<number>(0);
    const scrollViewRef = useRef<ScrollView>(null);
    const handlePageChange = (pageIndex: number) => {
        setActivePage(pageIndex);
        scrollViewRef.current?.scrollTo({ x: (pageIndex * windowWidth), y: 0, animated: true });
    };

    return (
        <View style={styles.container}>
            <View style={styles.header}>
                <Pressable onPress={() => handlePageChange(0)}>
                    <Text style={[styles.headerText, activePage === 0 && styles.activeHeaderText]}>Все записи</Text>
                </Pressable>
                <Pressable onPress={() => handlePageChange(1)}>
                    <Text style={[styles.headerText, activePage === 1 && styles.activeHeaderText]}>Задачи</Text>
                </Pressable>
                {/* <Pressable onPress={() => handlePageChange(2)}>
                    <Text style={[styles.headerText, activePage === 2 && styles.activeHeaderText]}>Календарь</Text>
                </Pressable> */}
            </View>
            <ScrollView
                horizontal
                pagingEnabled
                style={styles.scrollView}
                showsHorizontalScrollIndicator={false}
                ref={scrollViewRef}
                scrollEnabled={false}>

                <Post activePage={activePage}/>
                <Todos activePage={activePage}/>
                {/* <Calendar activePage={activePage}/> */}

            </ScrollView>
        </View>
    );
};

const styles = StyleSheet.create({
    container: {
        marginTop: 10,
        flex: 1,
        borderRadius: 10,
        backgroundColor: inputFieldColor,
    },
    scrollView: {
        flex: 1,
    },
    page: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        width: windowWidth - 20,
    },
    header: {
        flexDirection: 'row',
        justifyContent: 'space-around',
        alignItems: 'center',
        paddingVertical: 10,
        borderTopStartRadius: 10,
        borderBottomColor: 'white',
        borderBottomWidth: 3
    },
    headerText: {
        fontSize: 16,
        color: 'white',
    },
    activeHeaderText: {
        fontWeight: 'bold',
        color: 'white',
    },
});

export default TopTabNavigator;
