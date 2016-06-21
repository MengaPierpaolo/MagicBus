import React from 'react';
import FormGroup from 'react-bootstrap/lib/FormGroup';
import FormControl from 'react-bootstrap/lib/FormControl';
import ControlLabel from 'react-bootstrap/lib/ControlLabel';

export default class DescriptionEditor extends React.Component {
    constructor(props) {
        super(props);
    }

    onChange(e) {
        this.props.onChange('Description', e.target.value);
    }

    render() {
        return (
            <FormGroup>
                <ControlLabel>You consumed</ControlLabel>
                <FormControl type="text" defaultValue={this.props.description} onChange={this.onChange.bind(this) } />
                <FormControl.Feedback />
            </FormGroup>
        );
    }
}