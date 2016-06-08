import React from 'react';
import Title from './title.component'
import Dashboard from './dashboard.component'

export default class Layout extends React.Component {
  render() {
    return (
      <div className="Content">
        <Title title="Magic Bus" subTitle="Your groovy new travel diary - in ReactJs!" />
        {this.props.children}
      </div>
    );
  }
}
