import React, { Component } from 'react';
import './MenuBar.css';

export class MenuBar extends Component {
    static displayName = MenuBar.name;

  constructor (props) {
    super(props);
  }

  render () {
      return (
          <div className="bar">
              <div>
                  <div className="list"><a href="#" >Test text1</a></div>
                  <div className="list"><a href="#" >Test text2</a></div>
                  <div className="list"><a href="#" >Test text3</a></div>
              </div>
          </div>
    );
  }
}
