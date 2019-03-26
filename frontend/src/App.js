import React, { Component } from "react";
import { Route } from "react-router-dom";
import { Layout } from "./Components/Layout";
import Admin from "./Components/Admin/Admin.js";
import CreateModule from "./Components/Admin/createModule";
import EditLecturer from "./Components/Admin/editLecturer";
import Student from "./Components/Student/Student";
import Lecturer from "./Components/Lecturer/Lecturer";
import CreateAttendance from "./Components/Lecturer/CreateAttendance";
import AddResult from "./Components/Lecturer/AddResult";
import Home from "./Components/Home/Home";
import Login from "./Components/Login/Login";
import Register from "./Components/Register/Register";
import CreateAssessment from "./Components/Lecturer/CreateAssessment";
import ModuleDetails from "./Components/Student/moduleDetails";
import { runWithAdal } from "react-adal";
import { authContext } from "../src/configAzureFile.js";

runWithAdal(authContext, () => {
  // TODO : continue your process
});

class App extends Component {
  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <Route exact path="/login" component={Login} />
        <Route exact path="/register" component={Register} />
        <Route path="/moduleDetails" component={ModuleDetails} />
        <Route path="/admin" component={Admin} />
        <Route path="/createModule" component={CreateModule} />
        <Route path="/editLecturer" component={EditLecturer} />
        <Route path="/student" component={Student} />
        <Route path="/lecturer" component={Lecturer} />
        <Route path="/createAttendance" component={CreateAttendance} />
        <Route path="/addResult" component={AddResult} />
        <Route path="/createAssessment" component={CreateAssessment} />
      </Layout>
    );
  }
}

export default App;
