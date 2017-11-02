import { observable, action } from 'mobx';

class NotesStore {
  @observable Notes = []
  @observable TodoItems = []

  @action ResetTodoItems() {
    this.TodoItems = [];
  }

  @action GetNotes() {
    this.Notes = [
      {
        name: 'Hello',
        colour: 'Red',
      },
    ];
  }

  @action AddNote(_note) {
    this.Notes = [
      {
        name: 'Hello',
        colour: 'Red',
      },
    ];
  }

  @action DeleteNote(_id: number) {
    this.Notes = [];
  }

  @action GetTodoItems(_id: number) {
    this.TodoItems = [];
  }

  @action AddTodoItem(_id: number, _todoitem) {
    this.TodoItems = [];
  }

  @action DeleteTodoItem(_noteid: number, _todoitemid) {
    this.TodoItems = [];
  }
}

const notesStore = new NotesStore();
export default notesStore;
