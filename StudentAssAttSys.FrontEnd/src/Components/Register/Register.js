import React, { Component } from "react";
import { Link } from "react-router-dom";

export class Register extends Component {
  displayName = Register.name;

  render() {
    return (
      <div className="text-center">
        <form className="loginForm">
          <img
            className="mb-4"
            src="https://getbootstrap.com/docs/4.0/assets/brand/bootstrap-solid.svg"
            alt=""
            width="60"
            height="60"
          />
          <h1 className="h5 mb-3 font-weight-normal">Register</h1>
          <div className="form-group input-group-sm">
            <label htmlFor="inputEmail" className="sr-only">
              Email address
            </label>
            <input
              type="email"
              id="inputEmail"
              className="form-control "
              placeholder="Email address"
            />
          </div>
          <div className="form-group input-group-sm">
            <label htmlFor="pwd1" className="sr-only">
              Password
            </label>
            <input
              type="password"
              id="pwd1"
              className="form-control"
              placeholder="Password"
            />
          </div>
          <div className="form-group input-group-sm">
            <label htmlFor="pwd2" className="sr-only">
              Confirm Password
            </label>
            <input
              type="password"
              id="pwd2"
              className="form-control"
              placeholder="Password"
            />
          </div>

          <button className="btn btn-sm btn-primary btn-block" type="submit">
            Register
          </button>
          <p className="mt-5 mb-3 text-muted">&copy; 2017-2018</p>
          <p className="text-muted mb-3 font-weight-normal">
            Do you have an account already?
          </p>
          <Link to="/login">Login</Link>
        </form>
      </div>
    );
  }
}

export default Register;
