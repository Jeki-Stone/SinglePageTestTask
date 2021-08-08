import React, { Component } from 'react';
import { MenuBar } from './MenuBar';
import { NavMenu } from './NavMenu';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <NavMenu />
        <div>
          <MenuBar />
          <div >
            {this.props.children}
          </div>
        </div>
      </div>
    );
  }
}
