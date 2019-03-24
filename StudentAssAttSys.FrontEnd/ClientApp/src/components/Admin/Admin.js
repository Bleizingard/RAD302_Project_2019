import React, { Component } from "react";
import "../Admin/Admin.css";
import { Link } from "react-router-dom";

export class Admin extends Component {
  displayName = Admin.name;

  render() {
    return (
      <div>
        <h3>Hello, Admin!</h3>
        <hr />
        <h4>Modules List</h4>

        <Link to="/createModule">
          <button className="btn-primary btn"> Create New Module</button>{" "}
        </Link>
        <table className="table table-hover">
          <thead className="thead-dark">
            <tr>
              <th scope="col">Module ID</th>
              <th scope="col">Module Name</th>
              <th scope="col">Lecturer</th>
              <th scope="col">Edit Lecturer</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <th scope="row">1</th>
              <td>Module 1</td>
              <td>Lecturer 1</td>
              <td>
                <Link to="/assignLecturer" className="btn btn-primary btn-sm">
                  Edit Lecturer
                </Link>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    );
  }
}

export default Admin;
