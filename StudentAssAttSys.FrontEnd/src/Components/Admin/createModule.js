import React, { Component } from "react";
import "../Admin/Admin.css";
import { Link } from "react-router-dom";
import { getToken } from "../../configAzureFile.js";

export class CreateModule extends Component {
  displayName = CreateModule.name;
  constructor(props) {
    super(props);
    this.state = {
      moduleName: "",
      lecturer: "",
      GPA: 0,
      lecturers: [
        {
          Id: "L123",
          FirstName: "Padraig",
          LastName: "Harte",
          Email: "padraig.harte@itsligo.ie"
        },
        {
          Id: "L234",
          FirstName: "Paul",
          LastName: "Powell",
          Email: "paul.powell@itsligo.ie"
        }
      ],
      apiToken: ""
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidMount() {
    this.setState({
      apiToken: getToken()
    });
  }
  handleChange = e => {
    let newState = {};
    newState[e.target.name] = e.target.value;
    this.setState(newState);
  };

  handleSubmit(e) {
    e.preventDefault();
    console.log(this.state);
    var lecturer = this.state.lecturers.filter(obj => {
      return obj.Email === this.state.lecturer;
    });
    console.log(lecturer);

    fetch("https://localhost:44342/api/Module", {
      method: "PUT",
      mode: "cors",
      referrer: "no-referrer",

      headers: new Headers({
        Authorization: "Bearer " + this.state.apiToken,
        "Content-Type": "application/json"
      }),
      body: JSON.stringify({
        name: this.state.moduleName,
        GPAPercentage: 0,
        Lecturers: lecturer
      })
    })
      .then(res => console.log(res))
      .catch(err => console.log(err));
  }

  render() {
    const lecturers = this.state.lecturers;

    const options = lecturers.map(opt => (
      <option key={`${opt.FirstName}${opt.LastName}`} value={opt.Email}>
        {opt.FirstName} {opt.LastName}
      </option>
    ));

    return (
      <div className="col-sm-6 py-2">
        <h5>Create New Module</h5>
        <Link to="/admin">Go Back</Link>
        <hr />

        <form onSubmit={this.handleSubmit}>
          <div className="form-group input-group-sm">
            <label htmlFor="moduleName">Module Name</label>
            <input
              className="form-control"
              name="moduleName"
              type="text"
              id="moduleName"
              onChange={this.handleChange}
              value={this.state.moduleName}
            />
          </div>
          <div className="form-group input-group-sm">
            <label htmlFor="lecturers">Choose a Lecturer for this module</label>
            <select
              id="lecturer"
              name="lecturer"
              className="form-control"
              defaultValue=""
              onChange={this.handleChange}
            >
              <option value={this.state.lecturer} disabled hidden>
                Lecturers
              </option>
              {options}
            </select>
          </div>
          <div className="d-flex justify-content-center">
            <button type="submit" className="btn col-sm-4 btn-sm btn-primary">
              Submit
            </button>
          </div>
        </form>
      </div>
    );
  }
}

export default CreateModule;
