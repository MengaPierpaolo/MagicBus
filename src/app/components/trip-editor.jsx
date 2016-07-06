import React from 'react';
import { Link } from 'react-router';
import Button from 'react-bootstrap/lib/Button'
import DateEditor from './date-editor';
import LocationEditor from './location-editor';
import DescriptionEditor from './description-editor';
import ActivityStore from '../stores/ActivityStore';
import moment from 'moment';
import * as ActivityActions from '../actionCreators/activityActions'

export default class TripEditor extends React.Component {
    constructor(props) {
        super(props);
        this.getItem = this.getItem.bind(this);
        this.state = {
            on: moment().format("DD/MM/YYYY"),
            from: '',
            to: ''
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
        ActivityActions.saveActivity('Trip', this.state);
        this.context.router.push('/');
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
                    <Button className="btn btn-primary" onClick={this.onSaved.bind(this) }>Save It!</Button>
                    <Link to="/" className="btn btn-info">Changed my mind</Link>
                </form>
            </div>
        );
    }
}