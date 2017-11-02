import React from 'react';
import TestRenderer from 'react-test-renderer';

import HomePageView from 'pages/HomePage/View';

describe('NotesPage tests', () => {
  test('The NotesPage renders without any error', () => {
    const component = TestRenderer.create(<HomePageView datetime="Hello" />);

    let tree = component.toJSON();

    tree.props.datetime = 'Hello';

    tree = component.toJSON();
    expect(tree).toMatchSnapshot();
  });
});
