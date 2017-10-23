import $ from 'jquery';

let KinveyRequester = (function () {
    const base_url = 'https://baas.kinvey.com/';
    const app_id = 'kid_SkB_BD3fg';
    const app_secret = '724b375a75654cfab9fd4e5cb4e363e5';
    const appAuthHeaders = {
        Authorization: 'Basic ' + btoa(app_id + ':' + app_secret)
    };

    function loginUser(username, password) {
        return $.ajax({
            method: 'POST',
            url: base_url + 'user/' + app_id + '/login',
            headers: appAuthHeaders,
            data: JSON.stringify({ username, password }),
            contentType: 'application/json'
        });
    }

    function registerUser(username, password) {
        return $.ajax({
            method: 'POST',
            url: base_url + 'user/' + app_id,
            headers: appAuthHeaders,
            data: JSON.stringify({ username, password }),
            contentType: 'application/json'
        });
    }
    
    function loadPhotos() {
        return $.ajax({
            method: 'GET',
            url: base_url + 'appdata/' + app_id + '/photos',
            headers: getUserAuthHeaders(),
        });
    }
    
    function getUserAuthHeaders() {
        return {
            Authorization: 'Kinvey ' + sessionStorage.getItem('authToken')
        }
    }

    function uploadPhoto(title, author, photo, description) {
        return $.ajax({
            method: 'POST',
            url: base_url + 'appdata/' + app_id + '/photos',
            headers: getUserAuthHeaders(),
            data: {title, author, photo, description}
        });
    }

    function editPhoto(bookId, title, author, photo, description) {
        return $.ajax({
            method: 'PUT',
            url: base_url + 'appdata/' + app_id + '/photos/' + bookId,
            headers: getUserAuthHeaders(),
            data: {title, author, photo, description}
        });
    }

    function findPhotoById(photoId) {
        return $.ajax({
            method: 'GET',
            url: base_url + 'appdata/' + app_id + '/photos/' + photoId,
            headers: getUserAuthHeaders()
        });
    }

    return {
        loginUser,
        registerUser,
        loadPhotos,
        uploadPhoto,
        findPhotoById,
        editPhoto
    }
})();

export default KinveyRequester;