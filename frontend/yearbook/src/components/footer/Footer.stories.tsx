import React from 'react';
import { ComponentStory, ComponentMeta } from '@storybook/react';
// import SocialIconProps from './SocialIcon'
import githubLogo from "../../logos/github_logo.svg";
import { SocialIcon, SocialIconProps } from "./SocialIcon";

import { Footer } from './Footer';


export default {
    title: 'Components/Footer',
    component: Footer,

} as ComponentMeta<typeof Footer>;

// More on component templates: https://storybook.js.org/docs/react/writing-stories/introduction#using-args
const Template: ComponentStory<typeof Footer> = (args) => <Footer {...args} />;

const GITHUB_LOGO: SocialIconProps = {

    name: "GitHub",
    url: "https://github.com/399Hong/HomePage",
    logo: githubLogo
};

export const BasicFooter = Template.bind({});
// More on args: https://storybook.js.org/docs/react/writing-stories/args
BasicFooter.args = {
    iconInfo:[GITHUB_LOGO],
};