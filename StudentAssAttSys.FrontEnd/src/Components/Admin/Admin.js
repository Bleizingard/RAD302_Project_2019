import React, { Component } from "react";
import "../Admin/Admin.css";
import { Link } from "react-router-dom";
import { getToken } from "../../configAzureFile.js";

class LecturerRow extends Component {
  render() {
    var lecturers = this.props.lecturers;
    var lecturerRows = lecturers.map(lect => (
      <tr key={lect.Id}>
        <td>{lect.User.FullName}</td>
      </tr>
    ));
    return <table>{lecturerRows}</table>;
  }
}

export class Admin extends Component {
  displayName = Admin.name;
  constructor(props) {
    super(props);

    this.state = {
      modules: []
    };
  }

  componentDidMount() {
    fetch("https://localhost:44342/api/Modules", {
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
        console.log(res);
        this.setState({
          modules: res
        });
      })
      .catch(err => console.log(err));
  }

  render() {
    console.log(this.state);
    const moduleRow = this.state.modules.map(module => (
      <tr key={module.Id}>
        <td className="text-center">{module.Id}</td>
        <td className="text-center">{module.Name}</td>
        <td class="d-flex justify-content-center">
          {module.Lecturers.length > 0 ? (
            <LecturerRow lecturers={module.Lecturers} />
          ) : (
            `No lecturer`
          )}
        </td>
        <td className="text-center">{module.GPAPercentage}</td>
        <td className="text-center">
          <Link
            to={`/editLecturer/${module.Id}`}
            className="btn btn-primary btn-sm"
          >
            Add Lecturer
          </Link>
        </td>
      </tr>
    ));
    return (
      <div>
        <h5>Hello, Admin!</h5>
        <hr />
        <h6>Modules List</h6>

        <div className="py-3">
          <Link to="/createModule">
            <button className="btn-primary btn btn-sm">
              {" "}
              Create New Module
            </button>
          </Link>
        </div>
        <table className="table table-hover table-sm">
          <thead className="thead-dark text-center">
            <tr>
              <th scope="col">Module ID</th>
              <th scope="col">Module Name</th>
              <th scope="col">Lecturer</th>
              <th scope="col">GPA Percentage</th>
              <th scope="col">Edit Lecturer</th>
            </tr>
          </thead>
          <tbody>{moduleRow}</tbody>
        </table>
      </div>
    );
  }
}

export default Admin;
