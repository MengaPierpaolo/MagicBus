import React from 'react';
import { Link } from 'react-router'

export default class SightEditor extends React.Component {
    render() {
        return (
            <div>
                <p>Sight Editor</p>
                <Link to="/" className="btn btn-primary">Save It!</Link>
                <Link to="/" className="btn btn-info">Changed my mind</Link>
            </div>
        );
    }
}