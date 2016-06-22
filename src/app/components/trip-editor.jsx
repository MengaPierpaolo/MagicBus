import React from 'react';
import { Link } from 'react-router';
import Button from 'react-bootstrap/lib/Button'
import DateEditor from './date-editor';
import LocationEditor from './location-editor';
import DescriptionEditor from './description-editor';
import * as ActivityActions from '../actionCreators/activityActions'
import ActivityStore from '../stores/ActivityStore';
import * as axios from 'axios';

export default class TripEditor extends React.Component {
    constructor(props) {
        super(props);
        this.state = { date: '01/01/2016', from: 'blah', to: '', by: 'Bus' };
        this.getItem = this.getItem.bind(this);
    }

    static contextTypes = {
        router: React.PropTypes.object
    }

    componentWillMount() {
        ActivityStore.on("activityLoaded", this.getItem);
        if (typeof this.props.activityId != 'undefined')
            ActivityStore.loadActivity(this.props.activityId);
    }

    componentWillUnmount() {
        ActivityStore.removeListener("activityLoaded", this.getItem);
    }

    onClicked() {
        ActivityActions.saveActivity('Trip', this.state);
        this.context.router.push('/');
    }

    getItem() {
        this.setState(x); // TODO: not working
    }

    handleUserInput(inputLocation, inputValue) {
        this.setState({ [inputLocation]: inputValue });
    }

    render() {
        return (
            <div className='Content'>
                <form>
                    <DateEditor date={this.state.date} onChange={this.handleUserInput.bind(this) } />
                    <DescriptionEditor for='From' label='You travelled from' description={this.state.from} onChange={this.handleUserInput.bind(this) } />
                    <DescriptionEditor for='To' label='You travelled to' description={this.state.to} onChange={this.handleUserInput.bind(this) } />
                    <Button className="btn btn-primary" onClick={this.onClicked.bind(this) }>Save It!</Button>
                    <Link to="/" className="btn btn-info">Changed my mind</Link>
                </form>
            </div>
        );
    }
}