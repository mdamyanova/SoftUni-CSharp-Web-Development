import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import './App.css';

import NavigationBar from './Components/NavigationBar';
import Footer from './Components/Footer';

import HomeView from './Views/HomeView';
import LoginView from './Views/LoginView';

export default class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: sessionStorage.getItem('username'),
            userId: sessionStorage.getItem('userId')
        };
    }
    render() {
        return (
            <div className="App">
            <header>
                <NavigationBar username={this.state.username} homeClicked={this.showHomeView.bind(this)} loginClicked={this.showLoginView.bind(this)}/>
                <div id="errorBox">Error will come here</div>
                <div id="infoBox">Info will come here</div>
                <div id="loadingBox">Loading will come here</div>
            </header>
            <div id="main">
                <h1>Main</h1>
                <p>Main app view.</p>
            </div>
            <Footer/>
            </div>
    );
  }

  showView(reactComponent){
        ReactDOM.render(reactComponent, document.getElementById('main'));
  }

  showHomeView(){
        this.showView(<HomeView />);
  }

  showLoginView(){
      this.showView(<LoginView />);
  }
}