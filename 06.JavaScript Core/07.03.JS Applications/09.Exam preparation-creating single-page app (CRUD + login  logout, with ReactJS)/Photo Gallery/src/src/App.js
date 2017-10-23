import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import './App.css';
import $ from 'jquery';

import NavigationBar from './Components/NavigationBar';
import Footer from './Components/Footer';

import HomeView from './Views/HomeView';
import LoginView from './Views/LoginView';
import RegisterView from './Views/RegisterView';
import PhotosView from './Views/PhotosView';
import UploadPhotoView from './Views/UploadPhotoView';
import EditPhotoView from './Views/EditPhotoView';

import KinveyRequester from './KinveyRequester';

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
                    <NavigationBar
                        username={this.state.username}
                        homeClicked={this.showHomeView.bind(this)}
                        loginClicked={this.showLoginView.bind(this)}
                        registerClicked={this.showRegisterView.bind(this)}
                        photosClicked={this.showPhotosView.bind(this)}
                        uploadPhotoClicked={this.showUploadPhotoView.bind(this)}
                        logoutClicked={this.logout.bind(this)}
                    />
                    <div id="errorBox">Error will come here</div>
                    <div id="infoBox">Info will come here</div>
                    <div id="loadingBox">Loading...</div>
                </header>
                <div id="main"></div>
                <Footer/>
            </div>
        );
    }

    componentDidMount(){
        // Attach global AJAX 'loading' event handlers
        $(document).on({
            ajaxStart: function () {
                $('#loadingBox').show()
            },
            ajaxStop: function () {
                $('#loadingBox').hide()
            }
        });

        // Attach a global AJAX error handler
        $(document).ajaxError(this.handleAjaxError.bind(this));

        this.showHomeView();
        $('#errorBox, #infoBox').click(function () {
            $(this).hide();
        })
    }

    handleAjaxError(event, response){
        let errorMessage = JSON.stringify(response);
        if(response.readyState === 0){
            errorMessage = 'Cannot connect due to network error.';
        }
        if(response.responseJSON && response.responseJSON.description){
            errorMessage = response.responseJSON.description;
        }
        this.showError(errorMessage);
    }

    showInfo(message){
        $('#infoBox').text(message).show();
        setTimeout(function () {
            $('#infoBox').fadeOut();
        }, 3000);
    }

    showError(message) {
        $('#errorBox').text('Error: ' + message).show();
    }

    showView(reactComponent) {
        ReactDOM.render(reactComponent, document.getElementById('main'));
        $('#errorBox').hide();
    }

    showHomeView() {
        this.showView(<HomeView username={this.state.username} />);
    }

    showLoginView() {
        this.showView(<LoginView onsubmit={this.login.bind(this)}/>);
    }

    login(username, password) {
        KinveyRequester.loginUser(username, password)
            .then(loginSuccess.bind(this));

        function loginSuccess(userInfo) {
            this.saveAuthInSession(userInfo);
            this.showInfo('Login successful.');
            this.showPhotosView();
        }
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

    showRegisterView(){
        this.showView(<RegisterView onsubmit={this.register.bind(this)} />);
    }

    register(username, password) {
        KinveyRequester.registerUser(username, password)
            .then(registerSuccess.bind(this));

        function registerSuccess(userInfo) {
            this.saveAuthInSession(userInfo);
            this.showInfo('Register successful.');
            this.showPhotosView();
        }
    }

    showPhotosView(){
        KinveyRequester.loadPhotos()
            .then(loadPhotosSuccess.bind(this));

        function loadPhotosSuccess(photos) {
            this.showInfo('Photos loaded.');
            this.showView(<PhotosView photos={photos}
                                      onedit={this.loadPhotoForEdit.bind(this)}
                                      ondelete={this.loadPhotoForDelete.bind(this)} />);
        }
    }

    loadPhotoForEdit(photoId){
        KinveyRequester.findPhotoById(photoId)
            .then(findPhotoSuccess.bind(this));

        function findPhotoSuccess(photo) {
            let editPhotoView = <EditPhotoView
                photoId={photo._id}
                title={photo.title}
                author={photo.author}
                photo={photo.photo}
                description={photo.description}
                onsubmit={this.editPhoto.bind(this)}
            />;
            this.showView(editPhotoView);
        }
    }

    editPhoto(bookId, title, author, photo, description){
        // TODO: Add photo
        KinveyRequester.editPhoto(bookId, title, author, photo, description)
            .then(editPhotosSuccess.bind(this));

        function editPhotosSuccess() {
            this.showInfo('Photo edited.');
            this.showPhotosView();
        }
    }

    loadPhotoForDelete(photoId){

    }


    showUploadPhotoView(){
        this.showView(<UploadPhotoView onsubmit={this.uploadPhoto.bind(this)}/>);
    }

    uploadPhoto(title, author, photo, description){
        // TODO: Add photo
        KinveyRequester.uploadPhoto(title, author, photo, description)
            .then(uploadPhotosSuccess.bind(this));

        function uploadPhotosSuccess() {
            this.showInfo('Photos uploaded.');
            this.showPhotosView();
        }
    }

    logout() {
        sessionStorage.clear();

        // This will update the entire app UI (e.g. the navigation bar)
        this.setState({
            username: null,
            userId: null
        });
        this.showHomeView();
    }
}