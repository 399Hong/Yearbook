import React from "react";
import MenuIcon from "@material-ui/icons/Menu";
import { AppBar, createStyles, IconButton, makeStyles, Theme, Toolbar } from "@mui/material";
import { Button, Typography } from "@mui/material";
import { Box, spacing } from "@mui/system";
import { Sidebar } from "../sidebar/Sidebar"
import { styled } from '@mui/material/styles';
import { useState } from "react";
import Drawer from '@mui/material/Drawer';
// const Div = styled('div')``;


export default function Header() {
  const [sideBar, setSideBar] = useState(false);

  const toggleSideBar = (event:React.KeyboardEvent | React.MouseEvent) => {
    // if (event.type === 'keydown' && ((event as React.KeyboardEvent).key === 'Tab' || (event as React.KeyboardEvent).key === 'Shift')) {
    //   return;
    // }
    setSideBar(!sideBar);
  };


  return (

    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2 }}
            onClick={toggleSideBar}
          >
            <MenuIcon />
            <Drawer anchor="right" open={sideBar} onClose={toggleSideBar}>
            {/* selected both sibar and drawer content why? */}
              <Sidebar />
            </Drawer >
          </IconButton>
          <Typography align="center" variant="h6" component="div" sx={{ flexGrow: 1 }}>
            News
          </Typography>
          <Button color="inherit">Login</Button>
        </Toolbar>
      </AppBar>
    </Box>
  );


}