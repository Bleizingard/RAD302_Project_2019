import React, { Component } from "react";
import { Link } from "react-router-dom";

export class TableRow extends Component {
 
  render() {
    const row = this.props.row;

    return (
      <tr>
        <td key={row.module}>{row.module}</td>
        <td key={row.startDate}>{row.startDate}</td>
        <td key={row.startTime}>{row.startTime}</td>
        <td key={row.endDate}>{row.endDate}</td>
        <td key={row.endTime}>{row.endTime}</td>
      </tr>
    );
  }
}

export class CreateAssessment extends Component {
  displayName = CreateAssessment.name;
  constructor(props) {
    super(props);
    this.state = {
      module: "",
      startDate: "",
      startTime: "",
      endDate: "",
      endTime: "",
      testList: [{
        module: "RAD",
        startDate: "2019-03-29",
        startTime: "16:00",
        endDate: "2019-04-29",
        endTime: "16:00"
      }]
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
    let obj = {
      module: this.state.module,
      startDate: this.state.startDate,
      startTime: this.state.startTime,
      endDate: this.state.endDate,
      endTime: this.state.endTime
    };
    this.state.testList.push(obj);
    alert("new assessment added");
    e.preventDefault();
    console.log(this.state);
  };

  render() {
    const modules = ["Module 1", "Module 2", "Module 3", "Module 4"];
    const options = modules.map(opt => <option key={opt}>{opt}</option>);
    const list = this.state.testList.map((assess) =>
      (<TableRow row={assess}></TableRow>));
    return (
      <div className="col-sm-6 py-2">
        <h5>Create new assessment</h5>
        <Link to="/lecturer">Go Back</Link>
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
        <table className="table table-striped table-sm table-light table-hover">
          <thead>
            <tr>
              <th>
                Module:
            </th>
              <th>
                Start Date
            </th>
              <th>
                Start Time
            </th>
              <th>
                End Date
            </th>
              <th>
                End Time
              </th>
            </tr>
          </thead>
          <tbody>
            {list}
          </tbody>
        </table>
      </div >
    );
  }
}

export default CreateAssessment;
