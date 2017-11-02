import React, { Component } from 'react';

import View from './View';

class HomePage extends Component {
  constructor(props) {
    super(props);
    this.state = { date: new Date() };
  }

  componentDidMount = () => {
    this.timerID = setInterval(
      () => this.tick(),
      1000,
    );
  }

  componentWillUnmount() {
    clearInterval(this.timerID);
  }

  tick() {
    this.setState({
      date: new Date(),
    });
  }

  render() {
    const props = {
      datetime: this.state.date.toLocaleTimeString(),
    };
    return <View {...props} />;
  }
}

export default HomePage;
