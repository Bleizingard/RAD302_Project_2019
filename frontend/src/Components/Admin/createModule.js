import React, { Component } from "react";
import "../Admin/Admin.css";
import { Link } from "react-router-dom";

export class CreateModule extends Component {
  displayName = CreateModule.name;
  constructor(props) {
    super(props);
    this.state = {
      value: "",
      moduleName: ""
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({ value: event.target.value });
  }

  handleSubmit(event) {
    alert("A name was submitted: " + this.state.value);
    event.preventDefault();
  }

  render() {
    const lecturers = ["Lect 1", "Lect 2", "Lect 3", "Others"];
    const options = lecturers.map(opt => <option key={opt}>{opt}</option>);
    return (
      <div>
        <h5>Create New Module</h5>
        <hr />
        <form onSubmit={this.handleSubmit}>
          <div className="row">
            <div className="form-group input-group-sm col-sm-5">
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
          </div>
          <div className="row">
            <div className="form-group input-group-sm col-sm-5">
              <label htmlFor="lecturers">
                Choose a Lecturer for this module
              </label>
              <select
                id="lecturer"
                name="lecturer"
                className="form-control"
                defaultValue=""
                onChange={this.handleChange}
              >
                <option value="" disabled hidden>
                  Lecturers
                </option>
                {options}
              </select>
            </div>
          </div>
        </form>

        <div className="row pt-3">
          <div className="col-sm-4">
            <button
              type="submit"
              className="btn btn-sm btn-primary"
              onClick={this.onChange}
            >
              Save Changes
            </button>
          </div>
          <div className="col-sm-4">
            <Link to="/admin" className="btn btn-primary btn-sm">
              Go to Admin
            </Link>
          </div>
        </div>
      </div>
    );
  }
}

export default CreateModule;
