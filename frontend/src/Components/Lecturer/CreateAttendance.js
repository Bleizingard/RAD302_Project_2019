import React, { Component } from "react";

export class CreateAttendance extends Component {
  displayName = CreateAttendance.name;

  constructor(props) {
    super(props);
    this.state = {
      startTime: "",
      endTime: ""
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({ endTime: event.target.value });
    this.setState({ startTime: Date.now() });
  }

  handleSubmit(event) {
    alert(
      "An attendance was submitted: " +
        this.state.startTime +
        " " +
        this.state.endTime
    );
    event.preventDefault();
  }
  render() {
    return (
      <div>
            <h3>Choose end time for attendance</h3>
            <input type="datetime-local" onChange={this.handleChange}></input>
            <input type="button" onClick={this.handleSubmit}></input>
      </div>
    );
  }
}

export default CreateAttendance;
