import React from 'react';
import Button from 'react-bootstrap/lib/Button';
import { Link } from 'react-router'

import * as ActivityActions from '../actionCreators/activityActions';
import ActivityStore from '../stores/ActivityStore';

export default class ExperienceList extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      activityData: []
    };

    this.onDelete = this.onDelete.bind(this);
    this.getRecent = this.getRecent.bind(this);
    this.onExperienceClicked = this.onExperienceClicked.bind(this);
  }

  componentWillMount() {
    ActivityStore.on("change", this.getRecent);
    ActivityActions.loadActivities();
  }

  componentWillUnmount() {
    ActivityStore.removeListener("change", this.getRecent);
  }

  showLoader() {
    return ActivityStore.isLoading();
  }

  getRecent() {
    this.setState({
      activityData: ActivityStore.getRecentActivities()
    });
  }

  onExperienceClicked() {
    // TODO: Call Ordering functionality
  }

  onDelete(type, id) {
    ActivityActions.deleteActivity(type, id);
  }

  render() {
    var experiences = this.state.activityData.map(function (activity, index) {
      return <div className="experience" key={activity.id}>
        <Link to={`${activity.experienceType}/${activity.id}`} params={{activityId: activity.id}} className="clickable-experience">{activity.experience}</Link><br/>
        <Button onClick={this.onExperienceClicked} className="function-button glyphicon glyphicon-arrow-up"></Button>
        <Button onClick={this.onExperienceClicked} className="function-button glyphicon glyphicon-arrow-down"></Button>
        <Button onClick={() => { this.onDelete(activity.experienceType, activity.id) } } className="function-button glyphicon glyphicon-remove"></Button>
      </div >;
    }, this);

    return (
      <div>
        <h3>Recent experiences: </h3>
        { this.showLoader() ? <h2>Loading...</h2> : null }
        { experiences }
      </div>
    );
  }
}