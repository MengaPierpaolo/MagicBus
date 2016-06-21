import React from 'react';
import {browserHistory} from 'react-router';
import Button from 'react-bootstrap/lib/Button';
import { Link } from 'react-router'
import * as ChowActions from '../actionCreators/ChowActions';
import LocationEditor from './location-editor';
import DateEditor from './date-editor';
import DescriptionEditor from './description-editor';

export default class ChowEditor extends React.Component {
    constructor(props) {
        super(props);
        this.state = { date: '01/01/2016', description: '', location: '' };
    }

    onClicked() {
        ChowActions.saveChow(this.state);
        this.props.history.pushState(null, '/'); // TODO: Deprecated - move to new.
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
                    <DescriptionEditor description={this.state.description} onChange={this.handleUserInput.bind(this) } />
                    <Button className="btn btn-primary" onClick={this.onClicked.bind(this) }>Save It!</Button>
                    <Link to="/" className="btn btn-info">Changed my mind</Link>
                </form>
            </div>
        );
    }
}