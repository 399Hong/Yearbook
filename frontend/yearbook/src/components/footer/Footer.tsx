import { Grid } from "@mui/material";
import React from "react";
import { SocialIcon, SocialIconProps } from "./SocialIcon";
import githubLogo from "../../logos/github_logo.svg";
import { Box } from "@mui/system"

import PropTypes from 'prop-types';



const GITHUB_LOGO: SocialIconProps = {

    name: "GitHub",
    url: "https://github.com/399Hong/HomePage",
    logo: githubLogo
};

interface props {
    iconInfo: SocialIconProps[];
    msg: string;

};


export const Footer = ({ iconInfo, msg }: props) => (
    // https://github.com/microsoft/TypeScript/issues/33104
    // react args, cant take positional args
    <footer>
        <Box sx={{ bgcolor: "grey", bottom: 0 }}>
            <Grid container direction="row"
                justifyContent={{ xs: "center", sm: "space-between" }}
                alignItems="center"
            >
                {/* justifyContent="space-between"  -> evenly spaced, horizontal 
                    alignItems="center" -> vertically align
                 
                 */}

                <Grid item xs="auto"
                    sx={{
                        ml: 5, color: "white",
                        display: { xs: 'none', sm: "block" }
                    }}>
                    {/* sm(tablets is the) */}
                    {msg}
                </Grid>

                <Grid item  >
                    {iconInfo.map((x,index) => < SocialIcon key = {index}{...x }/> )}

                </Grid>

            </Grid>
        </Box>





    </footer>

);
Footer.propTypes = {
    msg: PropTypes.string,

};

Footer.defaultProps = {
    msg: `Copyright © Hong, ${new Date().getFullYear()}. All rights reserved`
}