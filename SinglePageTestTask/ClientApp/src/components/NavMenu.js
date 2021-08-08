import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);
    }

  render () {
    return (
        <header>
        <div className="navbar">
          <div>
            <h1 tag={Link} to="/">AB TEST REAL</h1>
            <img id="vector" src="images/Vector.png" />
                    <input tag={Text} id="search" />
                    <a href="#"><img id="ellipse" src="images/Ellipse.png" /></a>
                    <a href="#"><img id="logout" src="images/LogOut.png" /></a>
          </div>
        </div>
      </header>
    );
  }
}
