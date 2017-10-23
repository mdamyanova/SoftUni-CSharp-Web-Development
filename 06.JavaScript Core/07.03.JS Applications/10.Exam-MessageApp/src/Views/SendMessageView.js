import React, { Component } from 'react';


export default class SendMessageView extends Component {
    render() {
        let allUsers = this.users.map(user =>
            <option key={user.username}></option>);

        return (
            <section id="viewSendMessage">
                <h1>Send Message</h1>
                <form id="formSendMessage">
                    <div>Recipient:</div>
                    <div>
                        <select name="recipient" required id="msgRecipientUsername">
                            {allUsers}
                        </select>
                    </div>
                    <div>Message Text:</div>
                    <div><input type="text" name="text" required id="msgText"/></div>
                    <div><input type="submit" value="Send"/></div>
                </form>
            </section>
        );
    }
}