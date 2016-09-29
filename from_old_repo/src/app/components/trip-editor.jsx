import React from 'react';
import { Link } from 'react-router';
import Button from 'react-bootstrap/lib/Button'
import DateEditor from './date-editor';
import LocationEditor from './location-editor';
import DescriptionEditor from './description-editor';
import ActivityStore from '../stores/ActivityStore';
import moment from 'moment';
import * as ActivityActions from '../actionCreators/activityActions'

import FormControl from 'react-bootstrap/lib/FormControl';
import ControlLabel from 'react-bootstrap/lib/ControlLabel';

export default class TripEditor extends React.Component {
    constructor(props) {
        super(props);
        this.getItem = this.getItem.bind(this);
        this.state = {
            id: 0,
            on: moment().format("DD/MM/YYYY"),
            from: '',
            to: '',
            by: 1
        };
    }

    static contextTypes = {
        router: React.PropTypes.object
    }

    componentWillMount() {
        ActivityStore.on("activityLoaded", this.getItem);
    }

    componentWillUnmount() {
        ActivityStore.removeListener("activityLoaded", this.getItem);
    }

    componentDidMount() {
        if (typeof this.props.params.activityId != 'undefined') {
            ActivityStore.loadActivity('Trip', this.props.params.activityId);
        }
    }

    getItem() {
        this.setState(ActivityStore.getSelectedActivity());
    }

    onSaved() {
        if (typeof this.props.params.activityId != 'undefined') {
            ActivityActions.saveActivity('Trip', this.state, this.props.params.activityId);
        }
        else {
            ActivityActions.saveActivity('Trip', this.state);
        }
        this.context.router.push('/');
    }

    yourChangeHandler(e) {
        this.onUpdate('by', e.target.value);
    }

    onUpdate(name, value) {
        this.setState({ [name]: value });
    }

    render() {
        return (
            <div className='Content'>
                <form>
                    <DateEditor name="on" label="On" data={this.state.on} onUpdate={this.onUpdate.bind(this) }></DateEditor>
                    <DescriptionEditor name="from" label="You went from" data={this.state.from} onUpdate={this.onUpdate.bind(this) }></DescriptionEditor>
                    <DescriptionEditor name="to" label="You went to" data={this.state.to} onUpdate={this.onUpdate.bind(this) }></DescriptionEditor>
                    <ControlLabel>By</ControlLabel>
                    <FormControl componentClass="select" onChange={this.yourChangeHandler.bind(this) }>
                        <option value="1">Bus</option>
                        <option value="2">Train</option>
                    </FormControl>
                    <Button className="btn btn-primary" onClick={this.onSaved.bind(this) }>Save It!</Button>
                    <Link to="/" className="btn btn-info">Changed my mind</Link>
                </form>
            </div>
        );
    }
}