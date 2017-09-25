import React, { Component } from 'react';

export default class HomeView extends Component {
    render() {
        return (
            <div id="viewAppHome">
                <h1>Welcome</h1>
                { this.props.username ?
                    <p>Welcome, {this.props.username}!</p> :
                    <p> Welcome to our messaging system. </p>
                }
            </div>
        );
    }
}