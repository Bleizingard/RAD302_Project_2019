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
    event.preventDefault();
    console.log(this.state);
  }

  render() {
    return (
      <div className="py-3">
        <h5>Add results for students</h5>
        <hr />
        <div className="row">
          <div className="col-sm-8">
            <div className="d-flex justify-content-start">
              <h6>Type in the result for each student individually:</h6>
            </div>
          </div>
          <div className="col-sm-4">
            <div className="d-flex justify-content-end">
              <Link to="/lecturer">Go Back</Link>
            </div>
          </div>
        </div>
        <div className="pt-4">
          <table className="table table-hover table-sm">
            <thead className="thead-dark">
              <tr>
                <th scope="col-sm-6">Student Number</th>
                <th scope="col-sm-3">Input Result</th>
                <th scope="col-sm-3">Apply</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>S00184388</td>
                <td>
                  <div className="form-group input-group-sm col-sm-6 ">
                    <input
                      className="form-control"
                      name="result"
                      type="number"
                      id="result"
                      onChange={this.handleChange}
                      value={this.state.result}
                      required
                      autoFocus
                    />
                  </div>
                </td>
                <td>
                  <div
                    className="btn btn-primary btn-sm"
                    type="submit"
                    onClick={this.handleSubmit}
                  >
                    Add Result
                  </div>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    );
  }
}

export default AddResult;
