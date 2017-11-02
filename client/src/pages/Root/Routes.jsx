import React from 'react';
import { Route } from 'react-router-dom';

import HomePage from 'pages/HomePage';
import NotesPage from 'pages/NotesPage';
import TodoItemsPage from 'pages/TodoItemsPage';

const Routes = () => (
  <div style={{ margin: '1em' }}>
    <Route exact path="/" component={HomePage} />
    <Route exact path="/notes" component={NotesPage} />
    <Route path="/notes/:id" component={TodoItemsPage} />
  </div>
);

export default Routes;
