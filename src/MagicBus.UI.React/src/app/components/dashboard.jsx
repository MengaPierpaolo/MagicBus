import React from 'react'
import Row from 'react-bootstrap/lib/row';
import Col from 'react-bootstrap/lib/col';
import MenuButtons from './menu-buttons'
import ExperienceList from './experience-list'

export default class Dashboard extends React.Component {
    render() {
        return (
            <div>
                <Row>
                    <Col sm={5}>
                        <MenuButtons />
                    </Col>
                    <Col sm={1}>
                    </Col>
                    <Col sm={6}>
                        <ExperienceList />
                    </Col>
                </Row>
            </div>
        )
    }
}