import React, { Component } from "react";
import "../Admin/Admin.css";
import { Link } from "react-router-dom";
import { getToken } from "../../configAzureFile.js";

export class EditLecturer extends Component {
  displayName = EditLecturer.name;
  constructor(props) {
    super(props);
    this.state = {
      moduleId: this.props.match.params.moduleId,
      module: {},
      lecturer: "",
      lecturers: []
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.addLecturers = this.addLecturers.bind(this);
  }

  addLecturers() {
    var mockLecturers = [
      {
        Id: "123-abc-def",
        User: {
          Id: "123-abc-def",
          FirstName: "Paul",
          LastName: "Powell",
          Email: "paul.powell@itsligo.ie"
        }
      },
      {
        Id: "zef-933-sja",
        User: {
          Id: "zef-933-sja",
          FirstName: "Padraig",
          LastName: "Harte",
          Email: "padraig.harte@itsligo.ie"
        }
      }
    ];
    mockLecturers.forEach(Lecturer => {
      console.log(Lecturer);
      fetch(`https://localhost:44342/api/Lecturer`, {
        method: "PUT",
        mode: "cors",
        referrer: "no-referrer",

        headers: new Headers({
          Authorization: "Bearer " + getToken(),
          "Content-Type": "application/json"
        }),
        body: JSON.stringify({
          Id: Lecturer.Id,
          User: {
            FirstName: Lecturer.User.FirstName,
            LastName: Lecturer.User.LastName,
            Email: Lecturer.User.Email
          }
        })
      })
        .then(res => {
          console.log(res);
        })
        .catch(err => console.log(err));
    });
  }

  handleChange = e => {
    let newState = {};
    newState[e.target.name] = e.target.value;
    this.setState(newState);
  };

  handleSubmit = e => {
    e.preventDefault();
    var lecturer = this.state.lecturers.filter(obj => {
      return obj.User.Email === this.state.lecturer;
    })[0];

    fetch(
      `https://localhost:44342/api/Module/${this.state.moduleId}/addLecturer/${
        lecturer.Id
      }`,
      {
        method: "POST",
        mode: "cors",
        referrer: "no-referrer",

        headers: new Headers({
          Authorization: "Bearer " + getToken(),
          "Content-Type": "application/json"
        })
      }
    )
      .then(res => {
        console.log(res);
        if (res.status === 200) {
          alert("Lecturer added to this module");
        }
      })
      .catch(err => console.log(err));
  };

  componentDidMount() {
    fetch(`https://localhost:44342/api/Module/${this.state.moduleId}`, {
      method: "GET",
      mode: "cors",
      referrer: "no-referrer",
      headers: new Headers({
        Authorization: "Bearer " + getToken(),
        "Content-Type": "application/json"
      })
    })
      .then(res => {
        return res.json();
      })
      .then(res => {
        console.log(res);
        this.setState({ module: res });
      })
      .catch(err => console.log(err));

    fetch(`https://localhost:44342/api/Lecturers`, {
      method: "GET",
      mode: "cors",
      referrer: "no-referrer",
      headers: new Headers({
        Authorization: "Bearer " + getToken(),
        "Content-Type": "application/json"
      })
    })
      .then(res => {
        return res.json();
      })
      .then(res => {
        console.log(res);
        this.setState({ lecturers: res });
      })
      .catch(err => console.log(err));
  }

  render() {
    const lecturers = this.state.lecturers;
    const options = lecturers.map(opt => (
      <option
        key={`${opt.User.FirstName}${opt.User.LastName}`}
        value={opt.User.Email}
      >
        {opt.User.FirstName} {opt.User.LastName}
      </option>
    ));
    return (
      <div className="col-sm-6 py-2">
        <h5>Assign a new Lecturer for this module</h5>
        <Link to="/admin">Go Back</Link>
        <hr />
        <h6>
          <b>Module Name:</b> {this.state.module.Name}
        </h6>
        <h6>
          <b>Module Id:</b> {this.state.moduleId}
        </h6>
        <form onSubmit={this.handleSubmit} className="py-3">
          <div className="form-group input-group-sm">
            <h6 className="pt-3">Choose Lecturer</h6>
            <button className="btn btn-link" onClick={this.addLecturers}>
              Add mock lecturers to database
            </button>
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
            <button type="submit" className="btn btn-sm btn-primary col-sm-4">
              Submit
            </button>
          </div>
        </form>
      </div>
    );
  }
}

export default EditLecturer;
