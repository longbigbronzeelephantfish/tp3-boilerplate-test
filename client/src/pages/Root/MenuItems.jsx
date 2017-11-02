import React from 'react';
import { Link } from 'react-router-dom';
import { Menu } from 'semantic-ui-react';

const MainMenu = () => (
  <div>
    <Menu.Item header>Project Name</Menu.Item>
    <Menu.Item as={Link} to="/">Home</Menu.Item>
    <Menu.Item as={Link} to="/notes">Notes</Menu.Item>
  </div>
);

export default MainMenu;
