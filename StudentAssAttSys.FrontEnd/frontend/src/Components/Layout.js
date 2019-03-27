import React, { Component } from "react";
import { NavMenu } from "./Navbar/NavMenu";

export class Layout extends Component {
  displayName = Layout.name;

  render() {
    return (
      <div className="row">
        <div className="col-sm-3">
          <NavMenu
            role={this.props.role}
            name={this.props.name}
            studentNr={this.props.studentNr}
          />
        </div>
        <div className="col-sm-9">{this.props.children}</div>
      </div>
    );
  }
}

export default Layout;
