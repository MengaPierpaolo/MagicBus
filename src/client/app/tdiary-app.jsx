import React from 'react';
import {render} from 'react-dom';

import FirstComponent from './tdiary-first-component.jsx'

class Main extends React.Component {
  render () {
    return (
      <div>
        <p>React Based T Diary</p>
        <FirstComponent />
      </div>
    );
  }
}

render(<Main/>, document.getElementById('Main'));
