import React from 'react';
import { Header } from 'semantic-ui-react';

const View = props => (
  <div>
    <Header as="h1">Hello</Header>
    <p>The time now is: {props.datetime}.</p>
  </div>
);

export default View;
