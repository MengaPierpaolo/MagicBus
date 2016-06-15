import React from 'react';
import {browserHistory} from 'react-router';
import Button from 'react-bootstrap/lib/Button';
import FormGroup from 'react-bootstrap/lib/FormGroup';
import FormControl from 'react-bootstrap/lib/FormControl';
import ControlLabel from 'react-bootstrap/lib/ControlLabel';

import { Link } from 'react-router'

import * as ChowActions from '../actionCreators/ChowActions';

export default class ChowEditor extends React.Component {
    constructor(props) {
        super(props);
        this.state = { description: 'Hello' };
    }

    onClicked() {
        ChowActions.saveChow(this.state);
        this.props.history.pushState(null, '/'); // TODO: Deprecated - move to new.
    }

    onChange(e) {
        this.setState({ description: e.target.value });
    }

    render() {
        return (
            <form>
                <FormGroup controlId="formBasicText">
                    <ControlLabel>Working example with validation</ControlLabel>
                    <FormControl type="text"value={this.state.description} placeholder="Enter text" onChange={this.onChange.bind(this) } />
                    <FormControl.Feedback />
                </FormGroup>

                <Button className="btn btn-primary" onClick={this.onClicked.bind(this) }>Save It!</Button>
                <Link to="/" className="btn btn-info">Changed my mind</Link>
            </form>
        );
    }
}