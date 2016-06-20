import React from 'react';
import ReactDOM from 'react-dom';
import { Router, Route, IndexRoute, hashHistory } from 'react-router'

import Layout from './components/layout'
import Dashboard from './components/dashboard'
import TripEditor from './components/trip-editor'
import SightEditor from './components/sight-editor'
import ChowEditor from './components/chow-editor'
import NapEditor from './components/nap-editor'

// TODO: Remove this global namespace polluter!
// window.baseUrl = 'http://localhost:5000/api';
window.baseUrl = 'http://localhost:8002/api';

ReactDOM.render(
    <Router history={hashHistory}>
        <Route path="/" component={Layout}>
            <IndexRoute component={Dashboard}></IndexRoute>
            <Route path="Trip" component={TripEditor}></Route>
            <Route path="Sight" component={SightEditor}></Route>
            <Route path="Chow" component={ChowEditor}></Route>
            <Route path="Nap" component={NapEditor}></Route>
        </Route>
    </Router>,
    document.getElementById('App')
);