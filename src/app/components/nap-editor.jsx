import React from 'react';
import { Link } from 'react-router';

export default class NapEditor extends React.Component {
    render() {
        return (
            <div>
                <h2>Nap Editor</h2>
                <Link to="/" className="btn btn-primary">Save It!</Link>
                <Link to="/" className="btn btn-info">Changed my mind</Link>
            </div>
        )
    }
}