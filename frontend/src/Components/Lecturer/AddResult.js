import React, { Component } from "react";
import { Link } from "react-router-dom";

export class AddResult extends Component {
  constructor(props) {
    super(props);
    this.state = {
      //comes from API
      oldGrade: "89",
      //
      studentNumber: "",
      //new
      newGrade: ""
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
    if (
      this.state.newGrade > 0 &&
      this.state.newGrade !== this.state.oldGrade
    ) {
      this.setState({
        oldGrade: this.state.newGrade
      });
    }

    e.preventDefault();
    console.log(this.state);
  };

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
                <th scope="col-sm-4">Student Number</th>
                <th scope="col-sm-2" className="text-center">
                  Grade
                </th>
                <th scope="col-sm-2" className="text-center">
                  Edit Grade
                </th>
                <th scope="col-sm-3" className="text-center">
                  Add New Grade
                </th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>S00184388</td>
                <td className="text-center">{this.state.oldGrade}</td>
                <td>
                  <div className="form-group input-group-sm text-center ">
                    <input
                      className="form-control"
                      name="newGrade"
                      type="number"
                      id="result"
                      onChange={this.handleChange}
                      value={this.state.newGrade}
                    />
                  </div>
                </td>
                <td>
                  {this.state.newGrade === this.state.oldGrade ? (
                    <div
                      className="btn btn-danger btn-sm d-flex justify-content-center"
                      type="submit"
                      onClick={this.handleSubmit}
                    >
                      Edit Result
                    </div>
                  ) : (
                    <div
                      className="btn btn-primary btn-sm d-flex justify-content-center"
                      type="submit"
                      onClick={this.handleSubmit}
                    >
                      Add New Result
                    </div>
                  )}
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
