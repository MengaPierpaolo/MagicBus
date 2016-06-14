import React from 'react';
import Button from 'react-bootstrap/lib/Button';
import { Link } from 'react-router'

import * as ActivityActions from '../actions/ActivityActions';
import ActivityStore from '../stores/ActivityStore';

export default class ExperienceList extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      activityData: ActivityStore.getAll()
    };

    this.onCreate = this.onCreate.bind(this);
    this.onExperienceClicked = this.onExperienceClicked.bind(this);
    this.getAllActivities = this.getAllActivities.bind(this);
  }

  componentWillMount() {
    ActivityStore.on("change", this.getAllActivities);
  }

  componentWillUnmount() {
    ActivityStore.removeListener("change", this.getAllActivities);
  }

  getAllActivities() {
    this.setState({
      activityData: ActivityStore.getAll()
    });
  }

  onExperienceClicked() {
    alert('To Do');
  }

  onCreate() {
    ActivityActions.addActivity();
  }

  render() {
    var experiences = this.state.activityData.map(function (activity, index) {
      return <div className="experience" key={activity.id}>
          <Link to={activity.experienceType} className="clickable-experience">{activity.experience}</Link><br/>
          <Button onClick={this.onExperienceClicked} className="function-button promote">+</Button>
          <Button onClick={this.onExperienceClicked} className="function-button demote">-</Button>
          <Button onClick={this.onExperienceClicked} className="function-button delete-cross">x</Button>
        </div>;
    }, this);

    return (
      <div>
        <h3>Recent experiences: </h3>
        <Button onClick={this.onCreate}>Blah</Button>
        { experiences }
      </div>
    );
  }
}