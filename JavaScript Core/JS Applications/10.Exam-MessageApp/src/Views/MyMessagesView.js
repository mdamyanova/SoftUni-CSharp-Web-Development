import React, { Component } from 'react';

export default class MyMessagesView extends Component {
    render() {
        let messagesRows = this.props.messages.map(message =>
            <tr key={message._id}>
                <td>{this.formatSender(message.sender_username)}</td>
                <td>{message.text}</td>
                <td>{this.formatDate(message._kmd)}</td>
            </tr>
        );

        return (
            <div className="viewMyMessages">
                <h1>My Messages</h1>
                <table>
                    <thead>
                    <tr>
                        <th>From</th>
                        <th>Message</th>
                        <th>Date Received</th>
                    </tr>
                    </thead>
                    <tbody>
                    {messagesRows}
                    </tbody>
                </table>
            </div>
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

    formatSender(name, username) {
        if (!name)
            return username;
        else
            return username + ' (' + name + ')';
    }
}