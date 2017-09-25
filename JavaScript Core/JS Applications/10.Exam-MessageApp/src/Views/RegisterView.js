import React, { Component } from 'react';

export default class RegisterView extends Component {
    render() {
        return (
            <div id="viewRegister">
                <h1>Please register here</h1>
                <form id="formRegister" onSubmit={this.submitForm.bind(this)}>
                    <label>
                        <div>Username:</div>
                        <input type="text" name="username" id="registerUsername" required ref={e => this.usernameField = e} />
                    </label>
                    <label>
                        <div>Password:</div>
                        <input type="password" name="password" id="registerPasswd" required ref={e => this.passwordField = e} />
                    </label>
                    <label>
                        <div>Name:</div>
                        <input type="text" name="name" id="registerName"/>
                    </label>
                    <div>
                        <input type="submit" value="Register"/>
                    </div>
                </form>
            </div>
        );
    }

    submitForm(event) {
        event.preventDefault();
        this.props.onsubmit(
            this.usernameField.value, this.passwordField.value);
    }
}