import React, { Component } from "react";
import { Route } from "react-router-dom";
import "./App.css";
import { Layout } from "./Components/Layout";
import Admin from "./Components/Admin/Admin.js";
import CreateModule from "./Components/Admin/createModule";
import EditLecturer from "./Components/Admin/editLecturer";
import Student from "./Components/Student/Student";
import Lecturer from "./Components/Lecturer/Lecturer";
import { CreateAttendance } from "./Components/Lecturer/CreateAttendance";
import { AddResult } from "./Components/Lecturer/AddResult";
import Home from "./Components/Home/Home";

class App extends Component {
  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <Route path="/admin" component={Admin} />
        <Route path="/createModule" component={CreateModule} />
        <Route path="/editLecturer" component={EditLecturer} />
        <Route path="/student" component={Student} />
        <Route path="/lecturer" component={Lecturer} />
        <Route path="/createAttendance" component={CreateAttendance} />
        <Route path="/addResult" component={AddResult} />
      </Layout>
    );
  }
}

export default App;
