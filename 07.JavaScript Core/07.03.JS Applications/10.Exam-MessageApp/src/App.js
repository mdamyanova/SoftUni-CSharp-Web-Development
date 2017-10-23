import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import './App.css';

import NavigationBar from './Components/NavigationBar';
import Footer from './Components/Footer';
import HomeView from './Views/HomeView';
import LoginView from './Views/LoginView';
import RegisterView from './Views/RegisterView';
import MyMessagesView from './Views/MyMessagesView';
import ArchiveView from './Views/ArchiveView';
import SendMessageView from './Views/SendMessageView';

import KinveyRequester from './KinveyRequester';
import $ from 'jquery';

class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: sessionStorage.getItem("username"),
            userId: sessionStorage.getItem("userId")
        };
    }

    render() {
        return (
            <div className="App">
                <header>
                    <NavigationBar
                        username={this.state.username}
                        homeClicked={this.showHomeView.bind(this)}
                        loginClicked={this.showLoginView.bind(this)}
                        registerClicked={this.showRegisterView.bind(this)}
                        logoutClicked={this.logout.bind(this)}
                        myMessagesClicked={this.showMyMessagesView.bind(this)}
                        archiveClicked={this.showArchiveView.bind(this)}
                        sendMessageClicked={this.showSendMessageView.bind(this)}
                    />
                    <div id="loadingBox">Loading ...</div>
                    <div id="infoBox">Info</div>
                    <div id="errorBox">Error</div>
                </header>
                <main id="main">

                </main>
                <Footer/>
            </div>
        );
    }

    componentDidMount() {
        // Attach global AJAX "loading" event handlers
        $(document).on({
            ajaxStart: function () {
                $("#loadingBox").show()
            },
            ajaxStop: function () {
                $("#loadingBox").hide()
            }
        });

        // Attach a global AJAX error handler
        $(document).ajaxError(this.handleAjaxError.bind(this));

        // Hide the info / error boxes when clicked
        $("#infoBox, #errorBox").click(function () {
            $(this).fadeOut();
        });

        // Initially load the "Home" view when the app starts
        this.showHomeView();
    }

    handleAjaxError(event, response) {
        let errorMsg = JSON.stringify(response);
        if (response.readyState === 0)
            errorMsg = "Cannot connect due to network error.";
        if (response.responseJSON && response.responseJSON.description)
            errorMsg = response.responseJSON.description;
        this.showError(errorMsg);
    }

    showView(reactViewComponent) {
        ReactDOM.render(reactViewComponent,
            document.getElementById('main'));
        $('#errorBox').hide();
    }

    showInfo(message) {
        $('#infoBox').text(message).show();
        setTimeout(function () {
            $('#infoBox').fadeOut();
        }, 3000);
    }

    showError(errorMsg) {
        $('#errorBox').text("Error: " + errorMsg).show();
    }

    showHomeView() {
        this.showView(<HomeView username={this.state.username}/>);
    }

    showLoginView() {
        this.showView(<LoginView onsubmit={this.login.bind(this)}/>);
    }

    showRegisterView() {
        this.showView(<RegisterView onsubmit={this.register.bind(this)}/>);
    }

    login(username, password) {
        KinveyRequester.loginUser(username, password)
            .then(loginSuccess.bind(this));

        function loginSuccess(userInfo) {
            this.saveAuthInSession(userInfo);
            this.showHomeView();
            this.showInfo("Login successful.");
        }
    }

    register(username, password) {
        KinveyRequester.registerUser(username, password)
            .then(registerSuccess.bind(this));

        function registerSuccess(userInfo) {
            this.saveAuthInSession(userInfo);
            this.showHomeView();
            this.showInfo("User registration successful.");
        }
    }

    logout() {
        KinveyRequester.logoutUser();
        sessionStorage.clear();
        this.setState({username: null, userId: null});
        this.showHomeView();
        this.showInfo('Logout successful.');
    }

    saveAuthInSession(userInfo) {
        sessionStorage.setItem('authToken', userInfo._kmd.authtoken);
        sessionStorage.setItem('userId', userInfo._id);
        sessionStorage.setItem('username', userInfo.username);

        // This will update the entire app UI (e.g. the navigation bar)
        this.setState({
            username: userInfo.username,
            userId: userInfo._id
        });
    }

    showMyMessagesView() {
        KinveyRequester.findMyMessages()
            .then(loadMessagesSuccess.bind(this));

        function loadMessagesSuccess(messages) {
            this.showInfo("Messages loaded.");
            this.showView(
                <MyMessagesView
                    messages={messages}
                    userId={this.state.userId}
                />
            );
        }
    }

    showArchiveView() {
        KinveyRequester.findArchiveMessages()
            .then(loadMessagesSuccess.bind(this));

        function loadMessagesSuccess(messages) {
            this.showInfo("Messages loaded.");
            this.showView(
                <ArchiveView
                    messages={messages}
                    userId={this.state.userId}
                    deleteBookClicked={this.confirmMessageDelete.bind(this)}
                />
            );
        }
    }

    confirmMessageDelete(messageId) {
        KinveyRequester.deleteMessage(messageId)
            .then(deleteMessageSuccess.bind(this));

        function deleteMessageSuccess(response) {
            this.showArchiveView();
            this.showInfo('Messages deleted.');
        }
    }

    showSendMessageView() {
        KinveyRequester.findAllUsers()
            .then(loadUsersSuccess.bind(this));

        function loadUsersSuccess(users) {
            this.showInfo("Users loaded.");
            this.showView(
                <SendMessageView
                    users={users}
                    userId={this.state.userId}
                />
            );
        }
    }
}

export default App;
