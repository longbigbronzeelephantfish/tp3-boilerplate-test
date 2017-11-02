import { observable, action } from 'mobx';

import HTTPClient from 'services/HTTPClient';

/**
 *  This class is in charge of storing Notes and TodoItems state.
 *  The methods are used to add, get and delete Notes and TodoItems
 */
class NotesStore {
  @observable Notes = []
  @observable TodoItems = []

  @action ResetTodoItems() {
    this.TodoItems = [];
  }

  @action GetNotes() {
    return HTTPClient.Get('v2/notes')
      .then((res) => {
        this.Notes = res.data;
      });
  }

  @action AddNote(note) {
    return HTTPClient.Post('v2/notes', note)
      .then((_res) => {
        this.GetNotes();
      });
  }

  @action DeleteNote(id) {
    return HTTPClient.Delete(`v2/notes/${id}`)
      .then((_res) => {
        this.GetNotes();
      });
  }

  @action GetTodoItems(id) {
    return HTTPClient.Get(`v2/notes/${id}/todoitems`)
      .then((res) => {
        this.TodoItems = res.data;
      });
  }

  @action AddTodoItem(id, todoitem) {
    return HTTPClient.Post(`v2/notes/${id}/todoitems`, todoitem)
      .then((_res) => {
        this.GetTodoItems(id);
      });
  }

  @action DeleteTodoItem(noteid, todoitemid) {
    return HTTPClient.Delete(`v2/notes/${noteid}/todoitems/${todoitemid}`)
      .then((_res) => {
        this.GetTodoItems(noteid);
      });
  }
}

const notesStore = new NotesStore();
export default notesStore;
