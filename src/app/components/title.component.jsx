import React from 'react'
import Jumbotron from 'react-bootstrap/lib/Jumbotron';

export default class Title extends React.Component {
    render() {
        return (
        <Jumbotron>
          <h1>{this.props.title}</h1>
          <h2>{this.props.subTitle}</h2>
        </Jumbotron>
        )
    }
}