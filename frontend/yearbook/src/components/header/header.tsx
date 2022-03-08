import React from "react";
import MenuIcon from "@material-ui/icons/Menu";
import { AppBar, createStyles, IconButton, makeStyles, Theme, Toolbar } from "@mui/material";
import { Button, Typography } from "@mui/material";
import { Box, spacing } from "@mui/system";

import { styled } from '@mui/material/styles';

const Div = styled('div')``;


export default function Header() {



  return (

    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2}}
          >
            <MenuIcon />
          </IconButton>
          <Typography align="center" variant="h6" component="div" sx={{ flexGrow: 1}}>
            News
          </Typography>
          <Button color="inherit">Login</Button>
        </Toolbar>
      </AppBar>
    </Box>
  );


}