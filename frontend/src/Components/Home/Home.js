import React, { Component } from "react";
import { Link } from "react-router-dom";

export class Home extends Component {
  displayName = Home.name;

  render() {
    return (
      <div className="py-4">
        {/* <h5>Welcome!</h5>
        <h6>Home Page</h6>
        <div className="d-flex justify-content-center">
          <button className="btn btn-primary btn-sm">Login here</button>
          <p>Do you not have any account yet? </p>
          <Link to="/register">Register here</Link>
        </div> */}
        <div className="text-center">
          <div className="col-md-5  mx-auto my-5">
            <h4 className="font-weight-normal lead pt-3">
              Student Assessment Attendance System
            </h4>
            <h6 className="py-3">
              Manage assessments and attendances for each student!
            </h6>
            <Link
              to="/login"
              className="btn btn-outline-secondary btn-sm col-sm-4"
            >
              Login
            </Link>
            <p className="pt-3">No account yet?</p>
            <Link to="/register">Create one</Link>
          </div>
        </div>
      </div>
    );
  }
}
export default Home;
