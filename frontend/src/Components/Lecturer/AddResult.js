import React, { Component } from "react";
import { Link } from "react-router-dom";

export class AddResult extends Component {
  constructor(props) {
    super(props);
    this.state = {
      studentNumber: "",
      result: ""
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({ result: event.target.value });
  }

  handleSubmit(event) {
    alert(
      "A result was submitted: " +
        this.state.result +
        " For " +
        this.state.studentNumber
    );
    event.preventDefault();
  }

  render() {
    return (
      <div>
        <table className="table table-hover">
          <thead className="thead-dark">
            <tr>
              <th scope="col">Student Number</th>
              <th scope="col">Input Result</th>
              <th scope="col">Apply</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <th scope="row">1</th>
              <td>studentnumber</td>
              <td>
                <input
                  type="number"
                  placeholder="Enter result for student"
                  onChange={this.handleChange}
                />
              </td>
              <td>
                <input type="button" onClick={this.handleSubmit} />
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    );
  }
}
