import React from 'react'
import FormGroup from 'react-bootstrap/lib/FormGroup';
import ControlLabel from 'react-bootstrap/lib/ControlLabel';
import FormControl from 'react-bootstrap/lib/FormControl';

export default class DateEditor extends React.Component {
    constructor(props) {
        super(props);
    }

    onChange(e) {
        this.props.onUpdate(e.target.name, e.target.value);
    }

    render() {
        return (
            <FormGroup>
                <ControlLabel>{this.props.label}</ControlLabel>

                <FormControl
                    type="text"
                    name={this.props.name}
                    value={this.props.data}
                    onChange={this.onChange.bind(this) } />

                <FormControl.Feedback />
            </FormGroup>
        );
    }
}

