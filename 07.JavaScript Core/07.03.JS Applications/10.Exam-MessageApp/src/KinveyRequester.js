import $ from 'jquery';

const KinveyRequester = (function() {
    const baseUrl = "https://baas.kinvey.com/";
    const appKey = "kid_S1I-1K5mx";
    const appSecret = "07e896428366491381887d155f823d57";
    const kinveyAppAuthHeaders = {
        'Authorization': "Basic " + btoa(appKey + ":" + appSecret),
    };

    function loginUser(username, password) {
        return $.ajax({
            method: "POST",
            url: baseUrl + "user/" + appKey + "/login",
            headers: kinveyAppAuthHeaders,
            data: {username, password}
        });
    }

    function registerUser(username, password) {
        return $.ajax({
            method: "POST",
            url: baseUrl + "user/" + appKey + "/",
            headers: kinveyAppAuthHeaders,
            data: {username, password}
        });
    }

    function getKinveyUserAuthHeaders() {
        return {
            'Authorization': "Kinvey " + sessionStorage.getItem('authToken'),
        };
    }

    function logoutUser() {
        return $.ajax({
            method: "POST",
            url: baseUrl + "user/" + appKey + "/_logout",
            headers: getKinveyUserAuthHeaders(),
        });
    }

    function findMyMessages(){
        "use strict";
        return $.ajax({
            method: "GET",
            url: baseUrl + "appdata/" + appKey + `/messages?query={"sender_username":"${sessionStorage.username}"}`,
            dataType: 'json',
            headers: getKinveyUserAuthHeaders()
        });
    }

    function findArchiveMessages(){
        return $.ajax({
            method: "GET",
            url: baseUrl + "appdata/" + appKey + "/messages?query={\"sender_username\":\"" + this.username + "\"}",
            headers: getKinveyUserAuthHeaders()
        });
    }

    function deleteMessage(messageId) {
        return $.ajax({
            method: "DELETE",
            url: baseUrl + "appdata/" + appKey + "/messages/" + messageId,
            headers: getKinveyUserAuthHeaders()
        });
    }

    function findAllUsers() {
        return $.ajax({
            method: "GET",
            url: baseUrl + "user/" + appKey + "/",
            headers: getKinveyUserAuthHeaders()
        });
    }

    return {
        loginUser,
        registerUser,
        logoutUser,
        findMyMessages,
        findArchiveMessages,
        deleteMessage,
        findAllUsers
    }
})();

export default KinveyRequester;