import React from 'react';
import Button from 'react-bootstrap/lib/Button';
import { Link } from 'react-router'

export default class ExperienceList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {somethingGroovy : ''};
    this.onClickMe = this.onClickMe.bind(this);
  }

  onClickMe () {
    let stuff = this.state.somethingGroovy + ' Not amused.';
    this.setState({somethingGroovy: stuff});
  }

  render() {
    var activityData = ['Sight', 'Trip', 'Chow'];
    var buttons = activityData.map(function(name, index){
      return <div className="experience" key={index}>
        <Link to={name} className="clickable-experience">{name}</Link><br/>
        <Button onClick={this.onClickMe} className="function-button promote">+</Button>
        <Button onClick={this.onClickMe} className="function-button demote">-</Button>
        <Button onClick={this.onClickMe} className="function-button delete-cross">x</Button>

      </div>;
    }, this);

    return (
      <div>
        <h3>Recent experiences:</h3>
        { buttons }
        {this.state.somethingGroovy}
      </div>
    );
  }
}