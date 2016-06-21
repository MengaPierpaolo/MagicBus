import React from 'react'
import FormGroup from 'react-bootstrap/lib/FormGroup';
import FormControl from 'react-bootstrap/lib/FormControl';
import ControlLabel from 'react-bootstrap/lib/ControlLabel';

export default class DateEditor extends React.Component {
    constructor(props) {
        super(props);
    }

    onChange(e) {
        this.props.onChange('Date', e.target.value);
    }

    render() {
        return (
            <FormGroup>
                <ControlLabel>On</ControlLabel>
                <FormControl type="text" defaultValue={this.props.date} onChange={this.onChange.bind(this) } />
                <FormControl.Feedback />
            </FormGroup>
        );
    }
}

