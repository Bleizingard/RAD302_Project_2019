import React, { Component } from "react";
import { NavMenu } from "./Navbar/NavMenu";

export class Layout extends Component {
  displayName = Layout.name;

  render() {
    return (
      <div className="container-fluid">
        <div className="col-sm-3">
          <NavMenu />
        </div>
        <div className="col-sm-9">{this.props.children}</div>
      </div>
    );
  }
}

export default Layout;
