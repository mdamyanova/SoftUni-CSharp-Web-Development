import React, { Component } from 'react';

export default class LoginView extends Component {
    render() {
        return (
            <div id="viewLogin">
                <h1>Please login</h1>
                <form id="formLogin" onSubmit={this.submitForm.bind(this)}>
                    <label>
                        <div>Username:</div>
                        <input type="text" name="username" id="loginUsername" required ref={e => this.usernameField = e} />
                    </label>
                    <label>
                        <div>Password:</div>
                        <input type="password" name="password" id="loginPasswd" required  ref={e => this.passwordField = e}/>
                    </label>
                    <div>
                        <input type="submit" value="Login" />
                    </div>
                </form>
            </div>
        );
    }

    submitForm() {
        event.preventDefault();
        this.props.onsubmit(
            this.usernameField.value, this.passwordField.value);
    }
}