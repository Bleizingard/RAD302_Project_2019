import React, { Component } from "react";
import "../Admin/Admin.css";
import { Link } from "react-router-dom";

export class EditLecturer extends Component {
  displayName = EditLecturer.name;
  constructor(props) {
    super(props);
    this.state = { value: "" };

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
        <h3>Assign a new Lecturer for this module</h3>
        <hr />
        <form onSubmit={this.handleSubmit}>
          <div className="row">
            <div className="form-group input-group-sm col-sm-4">
              <label>Module Name:</label>
              <p>Module 1</p>

              <label htmlFor="lecturers">Choose Lecturer</label>
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
        <div className="row">
          <button
            type="submit"
            className="btn btn-sm btn-primary "
            onClick={this.onChange}
          >
            Save Changes
          </button>
        </div>
      </div>
    );
  }
}

export default EditLecturer;
