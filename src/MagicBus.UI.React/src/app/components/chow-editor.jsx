import React from 'react';
import { Link } from 'react-router';
import Button from 'react-bootstrap/lib/Button';
import DateEditor from './date-editor';
import LocationEditor from './location-editor';
import DescriptionEditor from './description-editor';
import ActivityStore from '../stores/ActivityStore';
import moment from 'moment';
import * as ActivityActions from '../actionCreators/activityActions';

export default class ChowEditor extends React.Component {
    constructor(props) {
        super(props);
        this.getItem = this.getItem.bind(this);
        this.state = {
            date: moment().format('DD/MM/YYYY'),
            description: '',
            location: ''
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
            ActivityStore.loadActivity('Chow', this.props.params.activityId);
        }
    }

    getItem() {
        this.setState(ActivityStore.getSelectedActivity());
    }

    onSaved() {
        if (typeof this.props.params.activityId != 'undefined') {
            ActivityActions.saveActivity('Chow', this.state, this.props.params.activityId);
        }
        else {
            ActivityActions.saveActivity('Chow', this.state);
        }
        this.context.router.push('/');
    }

    onUpdate(name, value) {
        this.setState({ [name]: value });
    }

    render() {
        return (
            <div className='Content'>
                <form>
                    <DateEditor name="date" label="On" data={this.state.date} onUpdate={this.onUpdate.bind(this) }></DateEditor>
                    <LocationEditor name="location" label="When you were in" data={this.state.location} onUpdate={this.onUpdate.bind(this) } />
                    <DescriptionEditor name="description" label="you consumed" data={this.state.description} onUpdate={this.onUpdate.bind(this) }></DescriptionEditor>
                    <Button className="btn btn-primary" onClick={this.onSaved.bind(this) }>Save It!</Button>
                    <Link to="/" className="btn btn-info">Changed my mind</Link>
                </form>
            </div>
        );
    }
}