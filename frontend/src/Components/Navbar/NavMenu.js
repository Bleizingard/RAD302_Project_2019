import React, { Component } from "react";
import "../Navbar/NavMenu.css";
import { Link } from "react-router-dom";

export class NavMenu extends Component {
  displayName = NavMenu.name;

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

        <div class="collapse navbar-collapse" id="navbarsExampleDefault">
          <ul class="navbar-nav mr-auto">
            <li class="nav-item active">
              <Link to="/" className="nav-link">
                Home<span className="sr-only">(current)</span>
              </Link>
            </li>
            <li class="nav-item">
              <Link to="/student" className="nav-link">
                Student<span className="sr-only">(current)</span>
              </Link>
            </li>
            <li class="nav-item">
              <Link to="/lecturer" className="nav-link">
                Lecturer<span className="sr-only">(current)</span>
              </Link>
            </li>
            <li class="nav-item">
              <Link to="/admin" className="nav-link">
                Admin<span className="sr-only">(current)</span>
              </Link>
            </li>
          </ul>
        </div>
      </nav>
    );
  }
}

export default NavMenu;
