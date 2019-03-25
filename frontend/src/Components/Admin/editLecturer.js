import React, { Component } from "react";
import "../Admin/Admin.css";

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
        <h5>Assign a new Lecturer for this module</h5>
        <hr />
        <form onSubmit={this.handleSubmit} className="py-3">
          <div className="row">
            <div className="form-group input-group-sm col-sm-4">
              <h6>
                <b>Module Name:</b> Module 2
              </h6>
              <h6 className="pt-3">Choose Lecturer</h6>
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

        <button
          type="submit"
          className="btn btn-sm btn-primary"
          onClick={this.onChange}
        >
          Save Changes
        </button>
      </div>
    );
  }
}

export default EditLecturer;
