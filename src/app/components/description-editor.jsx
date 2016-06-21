import React from 'react';
import FormGroup from 'react-bootstrap/lib/FormGroup';
import ControlLabel from 'react-bootstrap/lib/ControlLabel';
import FormControl from 'react-bootstrap/lib/FormControl';

export default class DescriptionEditor extends React.Component {
    constructor(props) {
        super(props);
    }

    onChangeDescription(e) {
        this.props.onChange(this.props.for, e.target.value);
    }

    render() {
        return (
            <FormGroup>
                <ControlLabel>{this.props.label}</ControlLabel>
                <FormControl type="text" value={this.props.from} onChange={this.onChangeDescription.bind(this)} />
                <FormControl.Feedback />
            </FormGroup>
        );
    }
}