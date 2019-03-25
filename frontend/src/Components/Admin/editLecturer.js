import React, { Component } from "react";
import "../Admin/Admin.css";
import { Link } from "react-router-dom";

export class EditLecturer extends Component {
  displayName = EditLecturer.name;
  constructor(props) {
    super(props);
    this.state = {
      module: "",
      lecturer: "",
      GPA: 0
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange = e => {
    let newState = {};
    newState[e.target.name] = e.target.value;
    this.setState(newState);
  };

  handleSubmit = async e => {
    alert("new assessment added");
    e.preventDefault();
    console.log(this.state);
  };

  render() {
    const lecturers = ["Lect 1", "Lect 2", "Lect 3", "Others"];
    const options = lecturers.map(opt => <option key={opt}>{opt}</option>);
    return (
      <div className="col-sm-6 py-2">
        <h5>Assign a new Lecturer for this module</h5>
        <Link to="/admin">Go Back</Link>
        <hr />
        <h6>
          <b>Module Name:</b> Module 2
        </h6>
        <form onSubmit={this.handleSubmit} className="py-3">
          <div className="form-group input-group-sm">
            <h6 className="pt-3">Choose Lecturer</h6>
            <select
              id="lecturer"
              name="lecturer"
              className="form-control"
              defaultValue=""
              onChange={this.handleChange}
            >
              <option value={this.state.lecturer} disabled hidden>
                Lecturers
              </option>
              {options}
            </select>
          </div>
          <div className="d-flex justify-content-center">
            <button type="submit" className="btn btn-sm btn-primary col-sm-4">
              Submit
            </button>
          </div>
        </form>
      </div>
    );
  }
}

export default EditLecturer;
