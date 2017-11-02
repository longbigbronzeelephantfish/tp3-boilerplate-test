import React from 'react';
import { shallow } from 'enzyme';

import NotesPage from 'pages/NotesPage';

jest.mock('stores');

describe('NotesPage tests', () => {
  test('The NotesPage renders without any error', () => {
    const component = shallow(<NotesPage />);

    expect(component.find('Header')).toBeTruthy();
    expect(true).toBeTruthy();
  });
});
