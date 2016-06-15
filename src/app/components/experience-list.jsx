import React from 'react';
import Button from 'react-bootstrap/lib/Button';
import { Link } from 'react-router'

import * as ActivityActions from '../actions/ActivityActions';
import ActivityStore from '../stores/ActivityStore';

export default class ExperienceList extends React.Component {
  constructor(props) {
    super(props);

    this.state = { activityData: [] };

    this.onExperienceClicked = this.onExperienceClicked.bind(this);
    this.getAllActivities = this.getAllActivities.bind(this);
    this.onDelete = this.onDelete.bind(this);
  }

  componentWillMount() {
    ActivityStore.on("change", this.getAllActivities);
    ActivityActions.reloadActivities();
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

  onDelete(id) {
    ActivityActions.deleteActivity(id);
  }

  render() {
    var experiences = this.state.activityData.map(function (activity, index) {
      return <div className="experience" key={activity.Id}>
        <Link to={activity.ExperienceType} className="clickable-experience">{activity.Experience}</Link><br/>
        <Button onClick={this.onExperienceClicked} className="function-button glyphicon glyphicon-arrow-up"></Button>
        <Button onClick={this.onExperienceClicked} className="function-button glyphicon glyphicon-arrow-down"></Button>
        <Button onClick={() => { this.onDelete(activity.Id) } } className="function-button glyphicon glyphicon-remove"></Button>
      </div>;
    }, this);

    return (
      <div>
        <h3>Recent experiences: </h3>
        { experiences }
      </div>
    );
  }
}