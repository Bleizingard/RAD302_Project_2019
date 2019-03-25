import React, { Component } from "react";

export class CreateAssessment extends Component {
  displayName = CreateAssessment.name;
  constructor(props) {
    super(props);
    this.state = {
      module: "",
      startDate: "",
      startTime: "",
      endDate: "",
      endTime: ""
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange = e => {
    let newState = {};
    newState[e.target.name] = e.target.value;
    this.setState(newState);
    console.log(this.state.newState);
  };

  handleSubmit = async e => {
    alert("new assessment added");
    e.preventDefault();
    console.log(this.state);
  };

  render() {
    const modules = ["Module 1", "Module 2", "Module 3", "Module 4"];
    const options = modules.map(opt => <option key={opt}>{opt}</option>);
    return (
      <div className="col-sm-6 py-2">
        <h5>Create new assessment</h5>
        <hr />
        <form onSubmit={this.handleSubmit}>
          <div className="form-group input-group-sm ">
            <label htmlFor="module">Choose a module</label>
            <select
              id="module"
              name="module"
              className="form-control"
              defaultValue=""
              onChange={this.handleChange}
            >
              <option value="" disabled hidden>
                Module..
              </option>
              {options}
            </select>
          </div>
          <div className="row">
            <div className="form-group input-group-sm col-sm-6 ">
              <label htmlFor="startDate">Start Date</label>
              <input
                className="form-control"
                name="startDate"
                type="date"
                id="startDate"
                onChange={this.handleChange}
                value={this.state.startDate}
              />
            </div>
            <div className="form-group input-group-sm col-sm-6 ">
              <label htmlFor="startTime">Time</label>
              <input
                className="form-control"
                name="startTime"
                type="time"
                id="startTime"
                onChange={this.handleChange}
                value={this.state.startTime}
              />
            </div>
          </div>
          <div className="row">
            <div className="form-group input-group-sm col-sm-6 ">
              <label htmlFor="endDate">End Date</label>
              <input
                className="form-control"
                name="endDate"
                type="date"
                id="endDate"
                onChange={this.handleChange}
                value={this.state.endDate}
              />
            </div>
            <div className="form-group input-group-sm col-sm-6 ">
              <label htmlFor="endTime">End Time</label>
              <input
                className="form-control"
                name="endTime"
                type="time"
                id="endTime"
                onChange={this.handleChange}
                value={this.state.endTime}
              />
            </div>
          </div>
          <div className="d-flex justify-content-center">
            <button type="submit" className="btn btn-sm btn-primary">
              Submit
            </button>
          </div>
        </form>
      </div>
    );
  }
}

export default CreateAssessment;
