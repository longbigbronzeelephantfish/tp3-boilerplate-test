import React, { Component } from 'react';
import { observer } from 'mobx-react';

import Stores from 'stores';

import View from './View';

/** This is the root page of the application */
@observer
class Root extends Component {
  constructor(props) {
    super(props);
    console.log('Application Loaded!');
    this.onButtonClick = this.onButtonClick.bind(this);
  }

  onButtonClick(_e) {
    Stores.HTTPStore.ClearError();
  }

  render() {
    const props = {
      error: Stores.HTTPStore.Error,
      onButtonClick: this.onButtonClick,
    };

    return <View {...props} />;
  }
}

export default Root;
