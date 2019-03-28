import React, { Component } from "react";
import { Link } from "react-router-dom";

export class ModuleDetails extends Component {
  constructor(props) {
    super(props);
    this.state = {
      ready: false
    };
  }

  async componentDidMount() {
    //the adress of the API
    const url = "https://api.randomuser.me/";
    //fetch is gonna do a http request to a specific URL for getting the data
    //async+await it;s gonna make the function syncronous, so when the response will be sent from the server, it will be saved in the const
    const response = await fetch(url);
    const data = await response.json();
    console.log(data.results[0].email);
  }
  render() {
    return (
      <div>
        <ul>
          <li>0</li>
          <li>1</li>
          <Link to="/student">Go Back</Link>
        </ul>
      </div>
    );
  }
}

export default ModuleDetails;
