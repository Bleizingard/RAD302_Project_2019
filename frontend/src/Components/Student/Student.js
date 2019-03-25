import React, { Component } from "react";
import { Link } from "react-router-dom";
import "../Student/Student.css";

import Calendar from "react-big-calendar";
import moment from "moment";
import "react-big-calendar/lib/css/react-big-calendar.css";

const localizer = Calendar.momentLocalizer(moment);

export class Student extends Component {
  displayName = Student.name;

  render() {
    const timing = ["Done", "To Be Done"];
    const options = timing.map(opt => <option key={opt}>{opt}</option>);

    var events = [
      {
        start: new Date(),
        end: new Date(moment().add(1, "days")),
        title: "RAD Assessment"
      }
    ];

    return (
      <div className="container-fluid" style={{ width: "100%" }}>
        <h5>Welcome,Student!</h5>
        <h6>Details</h6>

        <section id="tabs" className="project-tab ">
          <div className="row py-4 ">
            <div className="col-sm-12">
              <nav>
                <div
                  className="nav nav-tabs nav-fill ml-3"
                  id="nav-tab"
                  role="tablist"
                >
                  <div
                    className="link col-sm-4 active"
                    id="assessments-tab"
                    data-toggle="tab"
                    href="#assessments"
                    role="tab"
                    aria-controls="assessments"
                    aria-selected="true"
                  >
                    Assessments
                  </div>
                  <div
                    className="link col-sm-4"
                    id="modules-tab"
                    data-toggle="tab"
                    href="#modules"
                    role="tab"
                    aria-controls="modules"
                    aria-selected="false"
                  >
                    MyModules
                  </div>
                  <div
                    className="link col-sm-4"
                    id="timetable-tab"
                    data-toggle="tab"
                    href="#timetable"
                    role="tab"
                    aria-controls="timetable"
                    aria-selected="false"
                  >
                    Assessments Timetable
                  </div>
                </div>
              </nav>
              <div className="tab-content py-4" id="nav-tabContent">
                <div
                  className="tab-pane active"
                  id="assessments"
                  role="tabpanel"
                  aria-labelledby="assessments-tab"
                >
                  <div className="form-group input-group-sm col-sm-4 py-2">
                    <label htmlFor="timing">Filtered By</label>
                    <select
                      name="timing"
                      className="form-control"
                      defaultValue={""}
                      onChange={this.handleChange}
                    >
                      <option value="" disabled hidden>
                        Done/ToBeDone
                      </option>
                      {options}
                    </select>
                  </div>
                  <table className="table table-sm pt-3 ml-3">
                    <thead className="thead-dark text-center">
                      <tr>
                        <th scope="col-sm-2">Assessment</th>
                        <th scope="col">Module Name</th>
                        <th scope="col">Start Date</th>
                        <th scope="col">End Date</th>
                        <th scope="col">Grade</th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr className="text-center">
                        <th scope="row">1</th>
                        <td>RAD</td>
                        <td>18/03/2019</td>
                        <td>25/03/2019</td>
                        <td>-</td>
                      </tr>
                    </tbody>
                  </table>
                </div>
                <div
                  className="tab-pane"
                  id="modules"
                  role="tabpanel"
                  aria-labelledby="modules-tab"
                >
                  <table className="table table-sm pt-3">
                    <thead className="thead-dark">
                      <tr>
                        <th scope="col">#</th>
                        <th scope="col">Module Name</th>
                        <th scope="col">Lecturer</th>
                        <th scope="col">GPA</th>
                        <th scope="col">Details</th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <th scope="row">1</th>
                        <td>RAD</td>
                        <td>Paul Powell</td>
                        <td>-</td>
                        <td>
                          <Link to="/moduleDetails">View Details</Link>
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
                <div
                  className="tab-pane"
                  id="timetable"
                  role="tabpanel"
                  aria-labelledby="timetable-tab"
                >
                  <div>
                    <Calendar
                      localizer={localizer}
                      defaultDate={new Date()}
                      defaultView="month"
                      events={events}
                      style={{ height: "80vh" }}
                    />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </section>
      </div>
    );
  }
}

export default Student;
