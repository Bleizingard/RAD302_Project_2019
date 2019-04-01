import React, { Component } from "react";
import "../Navbar/NavMenu.css";
import { Link } from "react-router-dom";

export class NavMenu extends Component {
  displayName = NavMenu.name;

  clearSession() {
    console.log("session clear");
    localStorage.clear();
  }
  render() {
    return (
      <nav className="navbar navbar-expand-md navbar-dark bg-dark fixed-left">
        <button
          className="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarsExampleDefault"
          aria-controls="navbarsExampleDefault"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon" />
        </button>

        <div
          className="collapse navbar-collapse py-4"
          id="navbarsExampleDefault"
        >
          <ul className="navbar-nav mr-auto">
            <li className="nav-item active">
              <Link to="/" className="nav-link">
                <h6>Hello, {this.props.name}!</h6>
                <p>You are authorized as a {this.props.role}</p>
                {this.props.studentNr}
                <p />
              </Link>
            </li>
            <li className="nav-item">
              <Link to="/student" className="nav-link">
                Student<span className="sr-only">(current)</span>
              </Link>
            </li>
            <li className="nav-item">
              <Link to="/lecturer" className="nav-link">
                Lecturer<span className="sr-only">(current)</span>
              </Link>
            </li>
            <li className="nav-item">
              <Link to="/admin" className="nav-link">
                Admin<span className="sr-only">(current)</span>
              </Link>
            </li>
            <li className="nav-item">
              <a
                href="https://login.windows.net/mailitsligo.onmicrosoft.com/oauth2/logout?post_logout_redirect_uri=https://localhost:3000/"
                className="btn btn-sm btn-primary"
                onClick={this.clearSession}
              >
                LogOut
              </a>
            </li>
          </ul>
        </div>
      </nav>
    );
  }
}

export default NavMenu;
