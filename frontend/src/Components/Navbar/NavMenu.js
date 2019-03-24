import React, { Component } from "react";
import "../Navbar/NavMenu.css";
import { Link } from "react-router-dom";

export class NavMenu extends Component {
  displayName = NavMenu.name;

  render() {
    return (
      <nav className="navbar navbar-inverse bg-dark fixed-left">
        <Link to="/" className="navbar-brand">
          Brand
        </Link>
        <div className="navbar-collapse">
          <ul className="navbar-nav">
            <Link to="/admin">
              <li className="nav-link item">Admin</li>
            </Link>
            <Link to="/lecturer">
              <li className="nav-link item">Lecturer</li>
            </Link>
            <Link to="/student">
              <li className="nav-link item">Student</li>
            </Link>
          </ul>
        </div>
      </nav>
    );
  }
}

export default NavMenu;
