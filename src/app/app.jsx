import React from 'react';
import ReactDOM from 'react-dom';

import Jumbotron from 'react-bootstrap/lib/Jumbotron';
import Button from 'react-bootstrap/lib/Button';
import Row from 'react-bootstrap/lib/row';
import Col from 'react-bootstrap/lib/col';

import ActivityList from './activity-list.jsx'

class Main extends React.Component {
  render() {
    return (
      <div>
        <Jumbotron>
          <h1>Magic Bus</h1>
          <h2>Your groovy new travel diary - in ReactJs!</h2>
        </Jumbotron>
        <div className="Content">
          <Row>
            <Col sm={6}>
              <label>Wotcha been up to?</label><br />
              <Button bsStyle="primary">Been on a trip</Button>
              <Button bsStyle="primary">Had some chow</Button>
              <Button bsStyle="primary">Seen something funky</Button>
            </Col>
            <Col sm={6}>
              <ActivityList />
            </Col>
          </Row>
        </div>
      </div>
    );
  }
}

ReactDOM.render(<Main/>, document.getElementById('Main'));
