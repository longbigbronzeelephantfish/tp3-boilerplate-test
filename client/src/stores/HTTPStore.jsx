import { observable, action } from 'mobx';

/** This class is in change of storing HTTP errors */
class HTTPStore {
  @observable Error = '';

  @action ClearError() {
    this.Error = '';
  }

  @action SetError(error) {
    this.Error = error.message;
  }
}

const httpStore = new HTTPStore();
export default httpStore;
