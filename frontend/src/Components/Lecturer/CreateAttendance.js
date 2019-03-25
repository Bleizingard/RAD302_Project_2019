import React, { Component } from "react";

export class CreateAttendance extends Component {
  displayName = CreateAttendance.name;
  constructor(props) {
    super(props);
    this.state = {
      date: "",
      startTime: "",
      endTime: ""
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    var d = new Date();
    var h = d.getUTCHours();
    var m = d.getUTCMinutes();

    var d = h + ":" + m;
    this.setState({ endTime: event.target.value });
    this.setState({ date: new Date().toDateString() });
    this.setState({ startTime: d });
  }

  handleSubmit(event) {
    alert(
      "An attendance was submitted: " +
        this.state.startTime +
        " " +
        this.state.endTime +
        " " +
        this.state.date
    );
    this.setState({
      date: "",
      startTime: "",
      endTime: ""
    });
    event.preventDefault();
  }
  render() {
    const modules = ["Module 1", "Module 2", "Module 3", "Module 4"];
    const options = modules.map(opt => <option key={opt}>{opt}</option>);
    return (
      <div className="col-sm-6 py-2">
        <h5>Create new Attendance</h5>
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

export default CreateAttendance;
