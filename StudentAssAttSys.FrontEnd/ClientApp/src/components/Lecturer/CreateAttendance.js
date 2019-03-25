import React, { Component } from "react";
import { Link } from "react-router-dom";

export class CreateAttendance extends Component {
    displayName = Lecturer.name;

    constructor(props) {
        super(props);
        this.state = {
            startTime: "",
            endTime: ""
        }

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({ endTime: event.target.value });
        this.setState({ startTime: Date.now().toString() });
    }

    handleSubmit(event) {
        alert("An attendance was submitted: " + this.state.startTime + " " + this.state.endTime);
        event.preventDefault();
    }
    render() {
        return (
            <div>
                <h3>Choose end time for attendance</h3>
                <input type="datetime-local" onChange={this.handleChange}></input>
                <input type="submit" onClick={this.handleSubmit}>Submit Attendance</input>
            </div>
        );
    }
}