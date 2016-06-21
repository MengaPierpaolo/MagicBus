import React from 'react';
import FormGroup from 'react-bootstrap/lib/FormGroup';
import FormControl from 'react-bootstrap/lib/FormControl';
import ControlLabel from 'react-bootstrap/lib/ControlLabel';

export default class DescriptionEditor extends React.Component {
    constructor(props) {
        super(props);
        this.state = { usedFor: this.props.for || 'Description' }
    }

    onChange(e) {
        this.props.onChange(this.state.usedFor, e.target.value);
    }

    render() {
        return (
            <FormGroup>
                <ControlLabel>{this.props.label}</ControlLabel>
                <FormControl type="text" defaultValue={this.props.description} onChange={this.onChange.bind(this) } />
                <FormControl.Feedback />
            </FormGroup>
        );
    }
}