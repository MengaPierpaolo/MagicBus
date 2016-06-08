import React from 'react';
import { Link } from 'react-router'

export default class TripEditor extends React.Component {
    render() {
        return (
            <div>
                <p>Trip Editor</p>
                <Link to="/" className="btn btn-primary">Save It!</Link>
                <Link to="/" className="btn btn-info">Changed my mind</Link>
            </div>
        );
    }
}