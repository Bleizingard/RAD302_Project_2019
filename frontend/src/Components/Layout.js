import React, { Component } from "react";

export class Layout extends Component {
  displayName = Layout.name;

  render() {
    return (
      <div className="container-fluid">
        <div className="col-sm-3">
          <h1>Navbar</h1>
        </div>
        <div className="col-sm-9">{this.props.children}</div>
      </div>
    );
  }
}

export default Layout;
