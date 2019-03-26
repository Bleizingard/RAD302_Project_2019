import React, { Component } from "react";
import { Link } from "react-router-dom";
import "../Login/Login.css";
export class Login extends Component {
  displayName = Login.name;

  render() {
    return (
      <div className="text-center py-3">
        <form className="loginForm">
          <img
            className="mb-4"
            src="https://getbootstrap.com/docs/4.0/assets/brand/bootstrap-solid.svg"
            alt=""
            width="60"
            height="60"
          />
          <h1 className="h5 mb-3 font-weight-normal">Please sign in</h1>
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
            <label htmlFor="inputPassword" className="sr-only">
              Password
            </label>
            <input
              type="password"
              id="inputPassword"
              className="form-control"
              placeholder="Password"
            />
          </div>

          <button className="btn btn-sm btn-primary btn-block" type="submit">
            Sign in
          </button>
          <p className="mt-5 mb-3 text-muted">&copy; 2017-2018</p>
          <p className="text-muted mb-3 font-weight-normal">
            Do you not have any account yet?
          </p>
          <Link to="/register">Register here</Link>
        </form>
      </div>
    );
  }
}

export default Login;
