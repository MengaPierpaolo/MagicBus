import React from 'react'
import { Link } from 'react-router'

export default class MenuButtons extends React.Component{
    render() {
        return (
            <div>
                <h3>What'ya been up to?</h3>
                <Link to="Trip" className="btn btn-primary btn-block">Been on a trip</Link>
                <Link to="Chow" className="btn btn-primary btn-block">Had some chow</Link>
                <Link to="Sight" className="btn btn-primary btn-block">Saw something funky</Link>
                <Link to="/" className="btn btn-default btn-block">Took a noteworthy nap</Link>
            </div>
        )
    }
}
