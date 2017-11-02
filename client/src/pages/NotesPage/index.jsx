import React, { Component } from 'react';
import { observer } from 'mobx-react';

import { withRouter } from 'react-router-dom';

import Stores from 'stores';

import View from './View';

@observer
class NotesPage extends Component {
  constructor(props) {
    super(props);
    this.onNotesItemClick = this.onNotesItemClick.bind(this);
    this.onNotesItemDelete = this.onNotesItemDelete.bind(this);
    this.onNotesAdd = this.onNotesAdd.bind(this);
  }

  componentDidMount() {
    Stores.NotesStore.GetNotes()
      .catch((error) => {
        console.log(error);
      });
  }

  onNotesAdd(note) {
    Stores.NotesStore.AddNote(note)
      .catch((error) => {
        console.log(error);
      });
  }

  onNotesItemClick(id, _event) {
    this.props.history.push(`/notes/${id}`);
  }

  onNotesItemDelete(id, _event) {
    Stores.NotesStore.DeleteNote(id)
      .catch((error) => {
        console.log(error);
      });
  }

  render() {
    const props = {
      notes: Stores.NotesStore.Notes,
      onNotesItemClick: this.onNotesItemClick,
      onNotesItemDelete: this.onNotesItemDelete,
      onNotesAdd: this.onNotesAdd,
    };

    return <View {...props} />;
  }
}

export default withRouter(NotesPage);
