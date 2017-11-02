import React from 'react';
import { Button, Form, Header, List } from 'semantic-ui-react';

const colourOptions = [
  { text: 'Red', value: 'Red', icon: { color: 'red', name: 'tag' } },
  { text: 'Orange', value: 'Orange', icon: { color: 'orange', name: 'tag' } },
  { text: 'Yellow', value: 'Yellow', icon: { color: 'yellow', name: 'tag' } },
  { text: 'Green', value: 'Green', icon: { color: 'green', name: 'tag' } },
  { text: 'Blue', value: 'Blue', icon: { color: 'blue', name: 'tag' } },
  { text: 'Purple', value: 'Purple', icon: { color: 'purple', name: 'tag' } },
  { text: 'Violet', value: 'Violet', icon: { color: 'violet', name: 'tag' } },
];

const note = {
  name: 'Name',
  colour: 'Red',
};

const View = props => (
  <div>
    <Header as="h1">Notes</Header>

    <Form onSubmit={() => props.onNotesAdd(note)}>
      <Form.Group inline>
        <Form.Input
          onChange={(_e, { value }) => { note.name = value; }}
          placeholder={note.name}
        />
        <Form.Dropdown
          onChange={(_e, { value }) => { note.colour = value; }}
          selection
          defaultValue={note.colour}
          options={colourOptions}
        />
        <Form.Button type="submit">Add</Form.Button>
      </Form.Group>
    </Form>

    <List divided relaxed>
      {
      props.notes.map((object, _i) => (
        <List.Item key={object.noteId}>
          <List.Content floated="right">
            <Button onClick={() => props.onNotesItemDelete(object.noteId)}>
              Delete
            </Button>
          </List.Content>
          <List.Icon name="tag" color={object.colour.toLowerCase()} />
          <List.Content>
            <List.Header onClick={() => props.onNotesItemClick(object.noteId)}>
              {object.name}
            </List.Header>
          </List.Content>
        </List.Item>
      ))
    }
    </List>
  </div>
);

export default View;
