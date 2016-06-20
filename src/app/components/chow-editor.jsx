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
        this.state = { date: '01/01/2016', location: '', description: '' };
    }

    onClicked() {
        ChowActions.saveChow(this.state);
        this.props.history.pushState(null, '/'); // TODO: Deprecated - move to new.
    }

    onChangeOn(e) {
        this.setState({ date: e.target.value });
    }
    onChangeLocation(e) {
        this.setState({ location: e.target.value });
    }
    onChangeDescription(e) {
        this.setState({ description: e.target.value });
    }

    render() {
        return (
            <div className='Content'>
                <form>
                    <FormGroup>
                        <ControlLabel>On</ControlLabel>
                        <FormControl type="text"value={this.state.date} onChange={this.onChangeOn.bind(this) } />
                        <FormControl.Feedback />
                    </FormGroup>
                    <FormGroup>
                        <ControlLabel>When you were in</ControlLabel>
                        <FormControl type="text"value={this.state.location} onChange={this.onChangeLocation.bind(this) } />
                        <FormControl.Feedback />
                    </FormGroup>
                    <FormGroup>
                        <ControlLabel>You consumed</ControlLabel>
                        <FormControl type="text"value={this.state.description} onChange={this.onChangeDescription.bind(this) } />
                        <FormControl.Feedback />
                    </FormGroup>

                    <Button className="btn btn-primary" onClick={this.onClicked.bind(this) }>Save It!</Button>
                    <Link to="/" className="btn btn-info">Changed my mind</Link>
                </form>
            </div>
        );
    }
}