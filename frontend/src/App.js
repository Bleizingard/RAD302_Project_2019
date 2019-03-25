import React, { Component } from "react";
import { Route } from "react-router-dom";
import "./App.css";
import { Layout } from "./Components/Layout";
import Admin from "./Components/Admin/Admin.js";
import CreateModule from "./Components/Admin/createModule";
import EditLecturer from "./Components/Admin/editLecturer";
import Student from "./Components/Student/Student";

class App extends Component {
  render() {
    return (
      <Layout>
        <Route path="/admin" component={Admin} />
        <Route path="/createModule" component={CreateModule} />
        <Route path="/editLecturer" component={EditLecturer} />
        <Route path="/student" component={Student} />
      </Layout>
    );
  }
}

export default App;
