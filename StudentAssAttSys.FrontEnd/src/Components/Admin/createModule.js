import React, { Component } from "react";
import "../Admin/Admin.css";
import { Link } from "react-router-dom";
import { getToken } from "../../configAzureFile.js";

export class CreateModule extends Component {
  displayName = CreateModule.name;
  constructor(props) {
    super(props);
    this.state = {
      moduleName: "",
      GPA: 0,
      apiToken: ""
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidMount() {
    this.setState({
      apiToken: getToken()
    });
  }
  handleChange = e => {
    let newState = {};
    newState[e.target.name] = e.target.value;
    this.setState(newState);
  };

  handleSubmit(e) {
    e.preventDefault();
    console.log(this.state);

    fetch("https://localhost:44342/api/Module", {
      method: "PUT",
      mode: "cors",
      referrer: "no-referrer",

      headers: new Headers({
        Authorization: "Bearer " + this.state.apiToken,
        "Content-Type": "application/json"
      }),
      body: JSON.stringify({
        name: this.state.moduleName,
        GPAPercentage: 0
      })
    })
      .then(res => {
        console.log(res);
        if (res.status === 201) {
          alert("Module added");
          this.setState({
            moduleName: "",
            lecturer: ""
          });
        }
      })
      .catch(err => console.log(err));
  }

  render() {
    return (
      <div className="col-sm-6 py-2">
        <h5>Create New Module</h5>
        <Link to="/admin">Go Back</Link>
        <hr />

        <form onSubmit={this.handleSubmit}>
          <div className="form-group input-group-sm">
            <label htmlFor="moduleName">Module Name</label>
            <input
              className="form-control"
              name="moduleName"
              type="text"
              id="moduleName"
              onChange={this.handleChange}
              value={this.state.moduleName}
            />
          </div>
          <div className="d-flex justify-content-center">
            <button type="submit" className="btn col-sm-4 btn-sm btn-primary">
              Submit
            </button>
          </div>
        </form>
      </div>
    );
  }
}

export default CreateModule;
