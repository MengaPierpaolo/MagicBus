import React from 'react';
import { Link } from 'react-router'

export default class ChowEditor extends React.Component {
    render() {
        return (
            <div>
                <p>Chow Editor</p>
                <Link to="/" className="btn btn-primary">Save It!</Link>
                <Link to="/" className="btn btn-info">Changed my mind</Link>
            </div>
        );
    }
}