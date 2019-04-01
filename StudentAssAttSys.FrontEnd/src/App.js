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

  IsUserAlreadyInDb(token) {
    var found = false;
    return new Promise((resolve, reject) => {
      fetch("https://localhost:44342/api/Students", {
        method: "GET",
        mode: "cors",
        referrer: "no-referrer",
        headers: new Headers({
          Authorization: "Bearer " + getToken(),
          "Content-Type": "application/json"
        })
      })
        .then(res => {
          return res.json();
        })
        .then(res => {
          res.forEach(user => {
            if (user.Id === token.oid) {
              found = true;
            }
          });
          if (found) {
            resolve(true);
          } else {
            resolve(false);
          }
        })
        .catch(err => {
          console.log(err);
          reject(err);
        });
    });
  }

  TryAddUserToDB(token) {
    this.IsUserAlreadyInDb(token).then(res => {
      if (!res) {
        var endURL = "";
        if (this.setRole(token.unique_name) === "student") {
          endURL = "Student";
        } else if (this.setRole(token.unique_name) === "lecturer") {
          endURL = "Lecturer";
        }
        fetch(`https://localhost:44342/api/${endURL}`, {
          method: "PUT",
          mode: "cors",
          referrer: "no-referrer",

          headers: new Headers({
            Authorization: "Bearer " + this.state.apiToken,
            "Content-Type": "application/json"
          }),
          body: JSON.stringify({
            Id: token.oid,
            StudentNumber: this.getStudentNr(token.unique_name),
            User: {
              Id: token.oid,
              FirstName: token.given_name,
              LastName: token.family_name,
              Email: token.unique_name
            }
          })
        })
          .then(res => {
            if (res.status === 201) {
              alert("User added to database");
            }
          })
          .catch(err => console.log(err));
      }
    });
  }

  componentDidMount() {
    runWithAdal(authContext, () => {
      if (getToken()) {
        var unique = jwtDecode(getToken()).unique_name;
        var apiToken = getToken();
        var name = jwtDecode(getToken()).name;

        this.TryAddUserToDB(jwtDecode(getToken()));

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
      this.setState({
        studentNumber: studentNr
      });
    }
    return studentNr;
  }
  render() {
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
