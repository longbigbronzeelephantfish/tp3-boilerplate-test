import notesStore from './NotesStore';
import httpstore from './HTTPStore';

/** This class contains a reference to all the stores used in the application */
class Stores {
  NotesStore = notesStore
  HTTPStore = httpstore
}

const stores = new Stores();
export default stores;
