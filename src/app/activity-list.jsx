import React from 'react';
import Button from 'react-bootstrap/lib/Button';

class ActivityList extends React.Component {

  constructor(props) {
    super(props);
    this.state = {somethingGroovy : ''};
    this.onClickMe = this.onClickMe.bind(this);
  }

  onClickMe () {
    let stuff = this.state.somethingGroovy + ' Not THAT amazing.  ';
    this.setState({somethingGroovy: stuff});
  }

  render() {
    return (
      <div>
        <label>Recent experiences</label>
        <div>
        <Button bsStyle="primary" onClick={this.onClickMe}>
          Something Amazing
        </Button>
        <span>{this.state.somethingGroovy}</span>
        </div>
      </div>
    );
  }

}

export default ActivityList;
