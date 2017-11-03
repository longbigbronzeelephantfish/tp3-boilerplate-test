import React from 'react';

import { BrowserRouter } from 'react-router-dom';
import { Menu, Modal, Button } from 'semantic-ui-react';

import MenuItems from './MenuItems';
import Routes from './Routes';

const View = props => (
  <BrowserRouter>
    <div>
      <Modal open={props.error != ""} >
        <Modal.Header icon="warning circle">{props.error}</Modal.Header>
        <Modal.Content>
          <Modal.Description>
            <p>There was an error! Please try again!</p>
          </Modal.Description>
        </Modal.Content>
        <Modal.Actions>
          <Button onClick={props.onButtonClick} color="green" inverted>Ok</Button>
        </Modal.Actions>
      </Modal>
      <Menu vertical inverted fixed="left">
        <MenuItems />
      </Menu>
      <div style={{ marginLeft: '230px', marginTop: '30px' }}>
        <Routes />
      </div>
    </div>
  </BrowserRouter>
);

export default View;
