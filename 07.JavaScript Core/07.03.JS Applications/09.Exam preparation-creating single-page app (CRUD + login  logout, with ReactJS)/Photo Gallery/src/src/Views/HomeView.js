import React from 'react';

export default function HomeView(props) {
    return <div className="home-view">
        <h1>Welcome to home</h1>
        <p>Welcome to our Photo Gallery!</p>
        {
            props.username ?
            <p>Welcome, {props.username}!</p>
                : <p>No user logged in.</p>
        }
    </div>
}