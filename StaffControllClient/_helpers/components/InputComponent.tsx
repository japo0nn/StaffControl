import React from 'react';
import { StyleSheet, TextInput} from 'react-native';
import {
  inputFieldColor,
  whiteColor,
  windowWidth,
} from '../constant';

interface InputProps {
  placeholderText: string;
  onTypeText: (text: string, property: string) => void;
  propertyName: string;
  multiline: boolean;
  secureTextEntry: boolean | undefined
}

export default function Input({
  placeholderText,
  onTypeText,
  propertyName,
  multiline,
  secureTextEntry = false,
}: InputProps): JSX.Element {
  return (
    <TextInput
      style={styles.inputField}
      placeholder={placeholderText}
      placeholderTextColor={'#a1a1a1'}
      secureTextEntry = {secureTextEntry ?? false}
      onChangeText={(e) => onTypeText(e, propertyName)}
      multiline={multiline}
    />
  );
}

const styles = StyleSheet.create({
  inputField: {
    width: windowWidth - 40,
    paddingHorizontal: 10,
    marginVertical: 5,
    color: whiteColor,
    backgroundColor: inputFieldColor,
    borderRadius: 10,
  },
});
