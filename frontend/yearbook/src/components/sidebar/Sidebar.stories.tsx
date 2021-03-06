import React from 'react';
import { ComponentStory, ComponentMeta } from '@storybook/react';
import { Sidebar } from './Sidebar';


export default {
    title: 'Components/Sidebar',
    component: Sidebar

} as ComponentMeta<typeof Sidebar>;

// More on component templates: https://storybook.js.org/docs/react/writing-stories/introduction#using-args
const Template: ComponentStory<typeof Sidebar> = () => <Sidebar />;


export const BasicSidebar = Template.bind({});
// More on args: https://storybook.js.org/docs/react/writing-stories/args
// BasicSidebar.args = {
//     i
// };