import React, { useState } from "react";
import { TextField, Typography, Grid, Container } from "@material-ui/core";
import { Button } from '@mui/material';

export interface SubmitFormProps {

}
const isGithubUrl = (value: string) => {
    const urlRegex =
        /^(http[s]{0,1}:\/\/){0,1}(github.com\/)([a-zA-Z0-9\-~!@#$%^&*+?:_\/=<>\.]*)?$/i;
    return urlRegex.test(value);
};


export const SubmitForm = () => {
    const [projectName, setProjectName] = useState<string>("");
    const [githubUrl, setGithubUrl] = useState<string>("");
    const [description, setDescription] = useState("");
    const [submit, setSubmit] = useState(false);
    const [valid, setValid] = useState(true);

    const handleSubmit = async () => {
        if (projectName !== "" && isGithubUrl(githubUrl)) {
            console.log({ "projectName": projectName, "githubUrl": githubUrl, "Description": description });
            setValid(true);
        } else {
            setValid(false);
        }
    };

    return (

        <Container>
            <Typography variant="h4"> Submit your project!</Typography>
            <Grid container spacing={4}>
                {/* <Grid item xs = {12} sm = {6} > */}
                {[<Grid item xs={12} sm={6} >
                    <TextField
                        required
                        id="standard-basic"
                        label="Project Name"
                        fullWidth
                        error={!valid && projectName === ""}
                        value={projectName}
                        //className={hasFocus && projectName === "" ? "" : classes.root}
                        helperText={(!valid && projectName === "") ? "Invalid Project Name" : ""}
                        onChange={(e) => setProjectName(e.target.value)}
                    />
                </Grid>
                    ,
                <Grid item xs={12} sm={6} >
                    <TextField
                        id="standard-basic"
                        label="Github URL"
                        fullWidth
                        error={!valid && (githubUrl === "" || !isGithubUrl(githubUrl))}
                        value={githubUrl}
                        onChange={(e) => setGithubUrl(e.target.value)}
                        // className={
                        // valid && (githubUrl === "" || !isGithubUrl(githubUrl))
                        //     ? ""
                        //     : classes.root
                        // }
                        helperText={!valid && !isGithubUrl(githubUrl) ? "Invalid URL" : ""}
                    // can be simplified by setup a state
                    // or use formcontrol to have access formhelpertext
                    />
                </Grid>,
                <Grid item xs={12} sm={12}>
                    <TextField
                        id="outlined-multiline-static"
                        label="Description"
                        multiline
                        rows={5}
                        placeholder="Introduce your project..."
                        variant="outlined"
                        fullWidth
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                    />
                </Grid>

                ].map(x => x)}





                <Grid container justify="center">
                    <Button
                        //className="form_button"
                        //sx = {{ align-items: "center"}}
                        color="success"
                        variant="contained"
                        onClick={handleSubmit}
                        size="large"
                    > Submit</Button>
                </Grid>
            </Grid>
        </Container>
    );






};

