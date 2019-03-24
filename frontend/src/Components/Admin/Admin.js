import React, { Component } from "react";
import "../Admin/Admin.css";
import { Link } from "react-router-dom";

export class Admin extends Component {
  displayName = Admin.name;

  render() {
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
            </button>{" "}
          </Link>
        </div>
        <table className="table table-hover">
          <thead className="thead-dark text-center">
            <tr>
              <th scope="col">Module ID</th>
              <th scope="col">Module Name</th>
              <th scope="col">Lecturer</th>
              <th scope="col">Edit Lecturer</th>
            </tr>
          </thead>
          <tbody>
            <tr className="text-center">
              <th scope="row">1</th>
              <td>Module 1</td>
              <td>Lecturer 1</td>
              <td>
                <Link to="/editLecturer" className="btn btn-primary btn-sm">
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
