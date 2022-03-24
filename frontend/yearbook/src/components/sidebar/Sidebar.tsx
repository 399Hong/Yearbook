import React from "react";
import {
    Divider,
    Link,
    List,
    ListItem,
    ListItemIcon,
    ListItemText,
    makeStyles,
} from "@mui/material";
import ListItemButton from '@mui/material/ListItemButton';
import HomeIcon from '@mui/icons-material/Home';
import ArrowUpwardIcon from "@mui/icons-material/ArrowUpward";
import LoginIcon from '@mui/icons-material/Login';
import { Box } from "@mui/system"

export const Sidebar = () => {

    return (
        <Box sx={{ width: 250 }}>
            <List>
                {[
                    [<HomeIcon />, "Home"],
                    [<ArrowUpwardIcon />, "Submit"],
                    [<LoginIcon />, "Login"]

                ].map((icon) =>

                    <ListItemButton key = {icon[1]} >
                        {/* key = {icon[1]} gives an error ? bug? */}
                        <ListItemIcon>
                            {/* use to align icon properly  */}
                            {icon[0]}
                        </ListItemIcon>
                        <ListItemText primary={icon[1]} />
                    </ListItemButton>

                )}
            </List>
        </Box >




    );



};