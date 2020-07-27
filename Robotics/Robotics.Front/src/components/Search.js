import React from 'react';
import { Form, Col, Button } from "react-bootstrap";

export default class Search extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            filter: 'Title',
            filterValue: ''
        }
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(e) {
        if (e.target.type == "radio") {
            this.setState({ 'filter': e.target.value });
        }
        else {
            this.setState({ 'filterValue': e.target.value });
        }
    }

    handleSubmit(e) {
        //hay que modificar
        e.preventDefault();
        const { filter, filterValue } = this.state;
        this.props.search(filter, filterValue);
        console.log('handleSubmit');
    }

    render() {
        return (
            <Form onSubmit={this.handleSubmit.bind(this)}>
                <Form.Row>
                    <Form.Label as="legend" column sm={2} > Filter </Form.Label>
                    <Form.Check value="title" inline onChange={this.handleChange} name="formHorizontalRadios" label="Title" type='radio' id='title' defaultChecked />
                    <Form.Check value="authorName" inline onChange={this.handleChange} name="formHorizontalRadios" label="Author's Name" type='radio' id='authorName' />
                    <Form.Check value="publisherName" inline onChange={this.handleChange} name="formHorizontalRadios" label="Publisher's Name" type='radio' id='publisherName' />
                </Form.Row>
                <Form.Row className="align-items-center">
                    <Col xs="lg">
                        <Form.Control inline type="text" placeholder="Enter Filter" onChange={this.handleChange}/>
                    </Col>
                    <Col xs="auto">
                        <Button type="submit">
                            Submit
                        </Button>
                    </Col>
                </Form.Row>
            </Form>
        );
    }
}
