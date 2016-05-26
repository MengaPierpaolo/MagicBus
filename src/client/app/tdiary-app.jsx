import React from 'react';
import {render} from 'react-dom';

import Jumbotron from 'react-bootstrap/lib/Jumbotron';
import FirstComponent from './tdiary-first-component.jsx'

class Main extends React.Component {
  render () {
    return (
      <div>
      <Jumbotron>
        <h1>Funky App</h1>
        <p>Hello there Groovy React App!</p>
      </Jumbotron>
      <FirstComponent />
      </div>
    );
  }
}

render(<Main/>, document.getElementById('Main'));
