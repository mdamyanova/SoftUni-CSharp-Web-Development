import React, { Component } from 'react';
import './NavigationBar.css';

export default class NavigationBar extends Component {
    render() {
        if(this.props.username == null){
            return (
                <div className="navigation-bar">
                <a href="#" onClick={this.props.homeClicked.bind(this)}>Home</a>
                <a href="#" onClick={this.props.loginClicked.bind(this)}>Login</a>
                <a href="#" onClick={this.props.registerClicked.bind(this)}>Register</a>
            </div>
            );
        } else {
            return (
                // User logged in
                <div className="navigation-bar">
                    <a href="#" onClick={this.props.homeClicked.bind(this)}>Home</a>
                    <a href="#" onClick={this.props.photosClicked.bind(this)}>Photos</a>
                    <a href="#" onClick={this.props.uploadPhotoClicked.bind(this)}>Upload Photo</a>
                    <a href="#" onClick={this.props.logoutClicked}>Logout</a>
                    <span className="loggedInUser">
                        Welcome, {this.props.username}!
                    </span>
                </div>
            )
        }
    }
}