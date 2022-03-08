import { ComponentMeta, ComponentStory } from '@storybook/react';
import React from 'react';

import Header from "./header";
// make sure its the same name as exported in header

export default {
    title: "components/Header",
    component: Header

} as ComponentMeta <typeof Header>;

const Template: ComponentStory<typeof Header> = () => <Header/> // or const Template = () => <Header/>
// i think both ComponentMeta and ComponentStory<typeof Header>  are not required.
//as it does not cause any differnet on the UI?
// but the doc suggested that type must be explicity stated.


export const CustomizedHeader = Template.bind({});