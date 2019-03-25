import React, { Component } from "react";
import { Link } from "react-router-dom";

export class Lecturer extends Component {
    displayName = Lecturer.name;

    render() {
        return (
            <div>
                <h3>Hello, Lecturer!</h3>
                <hr />
                <h4>Modules List</h4>
                <table className="table table-hover">
                    <thead className="thead-dark">
                        <tr>
                            <th scope="col">Module ID</th>
                            <th scope="col">Module Name</th>
                            <th scope="col">Create Attendance</th>
                            <th scope="col">Create Assesment</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th scope="row">1</th>
                            <td>Module 1</td>
                            <td>
                                <Link to="/CreateAttendance" className="btn btn-primary btn-sm">
                                    Create Attendance
                </Link>
                                <td><Link to="CreateAssessment" className="btn btn-primary btn-sm">
                                    Create Assessment
                                </Link></td>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div >
        )
    }
}