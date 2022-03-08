import React from "react";
import IconButton from "@mui/material/IconButton";

export interface SocialIconProps{
    name:string;
    url:string;
    logo:string;
}

export const SocialIcon = ({name, url, logo}:SocialIconProps) =>{
    return(


        <IconButton href = {url}>

            <img src={logo} id={logo} height = "20px" alt={name} />

        </IconButton>
    )

}
