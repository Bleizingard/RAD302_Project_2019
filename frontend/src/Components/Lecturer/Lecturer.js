import React, { Component } from "react";
import { Link } from "react-router-dom";

export class Lecturer extends Component {
  displayName = Lecturer.name;

  render() {
    return (
      <div>
        <h5>Hello, Lecturer!</h5>
        <div className="row">
          <div className="col-sm-8">
            <div className="d-flex justify-content-start">
              <h6>Modules List</h6>
            </div>
          </div>
          <div className="col-sm-4">
            <div className="d-flex justify-content-end">
              <Link to="/">Go Home</Link>
            </div>
          </div>
        </div>

        <hr />

        <table className="table table-hover table-sm table-stripped">
          <thead className="thead-dark">
            <tr className="text-center">
              <th scope="col">Module ID</th>
              <th scope="col-3">Module Name</th>
              <th scope="col-3">Create Attendance</th>
              <th scope="col-3">Create Assesment</th>
              <th scope="col-3">Add Result</th>
            </tr>
          </thead>
          <tbody>
            <tr className="text-center">
              <th scope="row">1</th>
              <td>RAD</td>
              <td>
                <Link to="/CreateAttendance" className="btn btn-primary btn-sm">
                  Create Attendance
                </Link>
              </td>

              <td>
                <Link to="/CreateAssessment" className="btn btn-primary btn-sm">
                  Create Assessment
                </Link>
              </td>
              <td>
                <Link to="/AddResult" className="btn btn-primary btn-sm">
                  Add Result
                </Link>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    );
  }
}

export default Lecturer;
