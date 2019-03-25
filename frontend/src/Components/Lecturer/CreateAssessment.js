import React, { Component } from "react";

export class CreateAssessment extends Component {
    displayName = CreateAssessment.name;
    constructor(props) {
        super(props);
        this.state = {
            module: 0,
            startTime: "",
            endTime: ""
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleChange(event) {
        let newState = {};
        newState[event.target.name] = event.target.value;
        this.setState(newState);
    }
    handleSubmit(event) {
        alert("new assessment added" + this.state);
        event.preventDefault();
    }

    render() {
        const modules = ["1", "2", "3", "4"];
        const options = modules.map(opt => <option key={opt}>{opt}</option>);
        return (
            <div>
                <input type="datetime-local" placeholder="Enter start date of assessment" name="startTime" onChange={this.handleChange}></input>
                <input type="datetime-local" placeholder="Enter end date of assessment" name="endTime" onChange={this.handleChange}></input>
                <input type="select" name="module" onChange={this.handleChange}><option value="" disabled hidden >Please select a module</option>{options}</input>
                <input type="button" onClick={this.handleSubmit} value="submit assessment" />
            </div>
        );
    }
}

export default CreateAssessment;
