import React from 'react';
import { Link } from 'react-router';
import Button from 'react-bootstrap/lib/button'
import DateEditor from './date-editor';
import LocationEditor from './location-editor';
import DescriptionEditor from './description-editor';
import * as ActivityActions from '../actionCreators/activityActions'
import ActivityStore from '../stores/ActivityStore';
import * as axios from 'axios';

export default class TripEditor extends React.Component {
    constructor(props) {
        super(props);
        this.state = this.helper();
        //        this.state = { date: '01/01/2016', from: 'blah', to: '', by: 'Bus' };

        this.getItem = this.getItem.bind(this);
    }

    static contextTypes = {
        router: React.PropTypes.object
    }


    componentWillMount() {
        ActivityStore.on("activityLoaded", this.getItem);
        this.helper().then(
            d => {
                this.setState(d);
            });
    }

    componentWillUnmount() {
        ActivityStore.removeListener("activityLoaded", this.getItem);
    }

    componentDidMount() {
        this.helper().then(
            d => {
                this.setState(d);
            });
    }

    helper() {
        return axios.get(baseUrl + '/Trip/228')
            .then(function (response) {
                var data = {
                    from: response.data.From,
                    to: response.data.To,
                    by: response.data.By,
                    date: response.data.Date
                }
                return data;
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    onClicked() {
        ActivityActions.saveActivity('Trip', this.state);
        this.context.router.push('/');
    }

    getItem() {
        var x = this.helper();
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