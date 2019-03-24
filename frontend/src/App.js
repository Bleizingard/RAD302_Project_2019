import React, { Component } from "react";
import { Route } from "react-router-dom";
import "./App.css";
import { Layout } from "./Components/Layout";
import Admin from "./Components/Admin/Admin.js";
import CreateModule from "./Components/Admin/createModule";
import EditLecturer from "./Components/Admin/editLecturer";

class App extends Component {
  render() {
    return (
      <Layout>
        <Route path="/admin" component={Admin} />
        <Route path="/createModule" component={CreateModule} />
        <Route path="/editLecturer" component={EditLecturer} />
      </Layout>
    );
  }
}

export default App;
