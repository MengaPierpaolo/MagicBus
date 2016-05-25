import React from 'react';
import Button from 'react-bootstrap/lib/Button';

class FirstComponent extends React.Component {

  constructor(props) {
    super(props);
    this.state = {somethingGroovy : ''};
    this.onClickMe = this.onClickMe.bind(this);
  }

  onClickMe () {
    let stuff = this.state.somethingGroovy + 'Clicked ';
    this.setState({somethingGroovy: stuff});
  }

  render() {
    return (
      <div>
        Do Something else : <span>{this.state.somethingGroovy}</span>
        <div>
        <Button bsStyle="primary" bsSize="small" onClick={this.onClickMe}>
          Something
        </Button>
        </div>
      </div>
    );
  }

}

export default FirstComponent;
