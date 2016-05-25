import React from 'react';

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
        Do Something : <span>{this.state.somethingGroovy}</span>
        <div><button onClick={this.onClickMe}>Click Me</button></div>
      </div>
    );
  }

}

export default FirstComponent;
