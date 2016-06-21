import React from 'react'
import FormGroup from 'react-bootstrap/lib/FormGroup';
import FormControl from 'react-bootstrap/lib/FormControl';
import ControlLabel from 'react-bootstrap/lib/ControlLabel';

export default class LocationEditor extends React.Component {
    constructor(props) {
        super(props);
    }

    onChange(e) {
        this.props.onChange('Location', e.target.value);
    }

    render() {
        return (
            <FormGroup>
                <ControlLabel>When you were in</ControlLabel>
                <FormControl type="text" defaultValue={this.props.location} onChange={this.onChange.bind(this) } />
                <FormControl.Feedback />
            </FormGroup>
        );
    }
}