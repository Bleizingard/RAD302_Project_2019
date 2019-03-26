import React, { Component } from "react";
import { Link } from "react-router-dom";

export class Home extends Component {
  displayName = Home.name;

  render() {
    return (
      <div className="py-4">
        <div className="text-center">
          <div className="mx-auto my-5">
            <h4 className="font-weight-normal lead pt-3">
              Student Assessment Attendance System
            </h4>
            <h6 className="py-3">
              Manage assessments and attendances for each student!
            </h6>
            <Link
              to="/login"
              className="btn btn-outline-primary btn-sm col-sm-4"
            >
              Login
            </Link>
            <p className="pt-3 text-muted">No account yet?</p>
            <Link to="/register">Create one</Link>
          </div>
        </div>
      </div>
    );
  }
}
export default Home;
