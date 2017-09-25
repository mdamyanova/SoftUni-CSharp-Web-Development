import React, { Component } from 'react';

export default class MyMessagesView extends Component {
    render() {
        let messagesRows = this.props.messages.map(message =>
            <tr key={message._id}>
                <td>{message.recipient_username}</td>
                <td>{message.text}</td>
                <td>{this.formatDate(message._kmd)}</td>
                {this.getActions(message, this.props.userId)}
            </tr>
        );

        return (
            <section id="viewArchiveSent">
                <h1>Archive (Sent Messages)</h1>
                <div class="messages" id="sentMessages">
                    <table>
                        <thead>
                        <tr>
                            <th>To</th>
                            <th>Message</th>
                            <th>Date Sent</th>
                            <th>Actions</th>
                        </tr>
                        </thead>
                        <tbody>
                        {messagesRows}
                        </tbody>
                    </table>
                </div>
            </section>
        );
    }

    formatDate(dateISO8601) {
        let date = new Date(dateISO8601);
        if (Number.isNaN(date.getDate()))
            return '';
        return date.getDate() + '.' + padZeros(date.getMonth() + 1) +
            "." + date.getFullYear() + ' ' + date.getHours() + ':' +
            padZeros(date.getMinutes()) + ':' + padZeros(date.getSeconds());

        function padZeros(num) {
            return ('0' + num).slice(-2);
        }
    }

    getActions(message, userId) {
        return (
            <td>
                <input type="button" value="Delete"
                       onClick={this.props.deleteMessageClicked.bind(this, message._id)}/>
            </td>
        );
    }
}