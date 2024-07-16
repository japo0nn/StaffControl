import { atom } from "jotai";
import { Dimensions } from "react-native"

export const ServerUrl = 'http://staff-controll.kz'
export const signed = atom(false)
export const admin = atom(false)
export const token = atom('')

export const filterVisible = atom(false)

export const userID = atom('');
export const selectedTask = atom('')

export const backgroundColor = '#1c1c1c';
export const inputFieldColor = '#383838';
export const mainColor = 'white';
export const whiteColor = 'white';
export const blackColor = 'black';
export const tabColor = '#0f0f0f';
export const secondColor = '#a1a1a1';

export const windowWidth = Dimensions.get('window').width;