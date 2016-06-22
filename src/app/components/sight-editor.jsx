import React from 'react';
import { Link } from 'react-router';
import Button from 'react-bootstrap/lib/Button'
import DateEditor from './date-editor';
import LocationEditor from './location-editor';
import DescriptionEditor from './description-editor';
import * as ActivityActions from '../actionCreators/activityActions'

export default class SightEditor extends React.Component {
    constructor(props) {
        super(props);
        this.state = { date: '01/01/2016', name: '', location: '' };
    }

    static contextTypes = {
        router: React.PropTypes.object
    }

    onClicked() {
        ActivityActions.saveActivity('Sight', this.state);
        this.context.router.push('/');
    }

    handleUserInput(inputLocation, inputValue) {
            this.setState({ [inputLocation]: inputValue });
    }

    render() {
        return (
            <div className='Content'>
                <form>
                    <DateEditor date={this.state.date} onChange={this.handleUserInput.bind(this) } />
                    <LocationEditor location={this.state.location} onChange={this.handleUserInput.bind(this) } />
                    <DescriptionEditor for='Name' label='You saw' description={this.state.name} onChange={this.handleUserInput.bind(this) } />
                    <Button className="btn btn-primary" onClick={this.onClicked.bind(this) }>Save It!</Button>
                    <Link to="/" className="btn btn-info">Changed my mind</Link>
                </form>
            </div>
        );
    }
}