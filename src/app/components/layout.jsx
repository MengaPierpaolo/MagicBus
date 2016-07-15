import React from 'react';
import Toolbar from './toolbar'

import Title from './title'
import Dashboard from './dashboard'

export default class Layout extends React.Component {
  render() {
    return (
      <div>
        <Toolbar></Toolbar>
        <Title title="Magic Bus" subTitle="Your groovy new travel diary - in ReactJs!" />
        {this.props.children}
      </div>
    );
  }
}
