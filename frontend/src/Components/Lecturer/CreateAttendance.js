import React, { Component } from "react";

export class CreateAttendance extends Component {
  displayName = CreateAttendance.name;

  constructor(props) {
    super(props);
    this.state = {
      date: "",
      startTime: "",
      endTime: "",
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    var d = new Date();
    var h = d.getUTCHours();
    var m = d.getUTCMinutes();

    var d = h + ":" + m
    this.setState({ endTime: event.target.value });
    this.setState({date: new Date().toDateString()});
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
    return (
      <div className="col-sm-6 py-2">
            <h3>Choose end time for attendance</h3>
            <input type="time" onChange={this.handleChange} className="form-control"></input>
            <input type="button" onClick={this.handleSubmit} value="Submit Attendance" className="btn btn-sm btn-primary"></input>
      </div>
    );
  }
}

export default CreateAttendance;
