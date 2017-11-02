import React from 'react';
import { Button, Form, Header, List } from 'semantic-ui-react';

const todoitem = {
  name: 'Name',
};

const View = props => (
  <div>
    <Header as="h1">{props.name}</Header>

    <Form onSubmit={_e => props.onTodoItemAdd(todoitem)}>
      <Form.Group inline>
        <Form.Input
          onChange={(_e, { value }) => { todoitem.name = value; }}
          placeholder="Name"
        />
        <Form.Button type="submit">Add</Form.Button>
      </Form.Group>
    </Form>

    <List divided relaxed>
      {
      props.todoitems.map((object, _i) => (
        <List.Item key={object.todoItemId}>
          <List.Content floated="right">
            <Button onClick={() => { props.onTodoItemDelete(object.todoItemId); }}>
              Delete
            </Button>
          </List.Content>
          <List.Content >
            <List.Header>{object.name}</List.Header>
          </List.Content>
        </List.Item>
      ))
    }
    </List>
  </div>
);

export default View;
