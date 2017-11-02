import React, { Component } from 'react';
import { observer } from 'mobx-react';

import Stores from 'stores';

import View from './View';

@observer
class TodoItemsPage extends Component {
  constructor(props) {
    super(props);
    Stores.NotesStore.ResetTodoItems();
    this.noteId = this.props.match.params.id;
    this.noteName = Stores.NotesStore.Notes.filter(item => item.noteId == this.noteId)[0].name;
    this.onTodoItemAdd = this.onTodoItemAdd.bind(this);
    this.onTodoItemDelete = this.onTodoItemDelete.bind(this);
  }

  componentDidMount() {
    Stores.NotesStore.GetTodoItems(this.noteId)
      .catch((error) => {
        console.log(error);
      });
  }

  onTodoItemAdd(todoitem) {
    const newtodo = todoitem;
    newtodo.completed = false;
    newtodo.noteId = this.noteId;
    Stores.NotesStore.AddTodoItem(this.noteId, newtodo)
      .catch((error) => {
        console.log(error);
      });
  }

  onTodoItemDelete(todoid) {
    Stores.NotesStore.DeleteTodoItem(this.noteId, todoid)
      .catch((error) => {
        console.log(error);
      });
  }

  render() {
    const props = {
      name: this.noteName,
      todoitems: Stores.NotesStore.TodoItems,
      onTodoItemAdd: this.onTodoItemAdd,
      onTodoItemDelete: this.onTodoItemDelete,
    };
    return <View {...props} />;
  }
}

export default TodoItemsPage;
