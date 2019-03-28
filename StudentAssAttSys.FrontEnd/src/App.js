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
import { authContext, getToken } from "../src/configAzureFile.js";
import jwtDecode from "jwt-decode";

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      uniqueName: "",
      role: "",
      name: "",
      studentNumber: "",
      apiToken: ""
    };
  }

  componentDidMount() {
    runWithAdal(authContext, () => {
      console.log(getToken());
      if (getToken()) {
        var unique = jwtDecode(getToken()).unique_name;
        var apiToken = getToken();
        var name = jwtDecode(getToken()).name;

        this.setState({
          uniqueName: unique,
          name: name,
          apiToken: apiToken
        });
        var role = this.setRole(unique);
        if (role === "student") {
          this.getStudentNr(unique);
        }
      }
    });
  }

  setRole(email) {
    var role = "";
    if (email.includes("@mail.itsligo.ie")) {
      role = "student";
    } else if (email.includes("@itsligo.ie")) {
      role = "lecturer";
    } else {
      role = "unknown";
    }
    this.setState({
      role: role
    });
    return role;
  }

  getStudentNr(email) {
    if (email) {
      var studentNr = email.substr(0, email.indexOf("@"));
      console.log(studentNr);
      this.setState({
        studentNumber: studentNr
      });
    }
  }
  render() {
    var apiToken = this.state.apiToken;
    console.log(this.state);
    console.log(apiToken);
    return (
      <Layout
        role={this.state.role}
        name={this.state.name}
        studentNr={this.state.studentNumber}
      >
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
