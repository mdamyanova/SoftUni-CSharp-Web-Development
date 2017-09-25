import React, { Component } from 'react';
import './NavigationBar.css';

export default class NavigationBar extends Component {
    render() {
        if(this.props.username == null){
            return (
                <div className="navigation-bar">
                <a href="#" onClick={this.props.homeClicked.bind(this)}>Home</a>
                <a href="#" onClick={this.props.loginClicked.bind(this)}>Login</a>
                <a href="#">Register</a>
            </div>
            );
        } else {
            return (
                <div className="navigation-bar">
                    <a href="#">Home</a>
                    <a href="#">Photos</a>
                    <a href="#">Upload Photo</a>
                    <a href="#">Logout</a>
                </div>
            )
        }
    }
}