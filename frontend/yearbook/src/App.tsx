import React from "react";
import { Button } from "@material-ui/core";
import "./App.css";
import Header from "./components/header/header"

function App() {
  return (
    <div className="App">
      <Header />
      <Button color="secondary" variant="contained" >HELLO WORLD</Button>
    </div>
  );
}

export default App;  