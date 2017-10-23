const kinveyBaseUrl = 'https://baas.kinvey.com';
const kinveyAppKey = 'kid_S1PXfBXfx';
const kinveyAppSecret = '409d7496cf9245808da9d75d5629be3c';
const base64auth = btoa(`${kinveyAppKey}:${kinveyAppSecret}`);
const kinveyAppAuthHeaders = {
    'Authorization': `Basic ${base64auth}`,
    'Content-Type': 'application/json'
};

function startApp() {
    showHideMenuLinks();

    attachMenuLinksEvents();

    attachButtonsEvents();

    showHomeView();

    $(document).on({
        ajaxStart: () => $('#loadingBox').show(),
        ajaxStop: () => {
            $('#loadingBox').hide();
        }
    });
}

function attachButtonsEvents () {
    $('#buttonRegisterUser').click(registerUser);
    $('#buttonLoginUser').click(loginUser);
    $('#buttonCreateAd').click(createAd);
    $('#buttonEditAd').click(editAd);
}

function editAd () {
    let adId = $('#formEditAd input[name=id]').val();
    let dateInfo = $('#formEditAd input[name=datePublished]').val().split('-');
    let dateCreated = `${dateInfo[1]}/${dateInfo[2]}/${dateInfo[0]}`;
    let price = Number($('#formEditAd input[name=price]').val()).toFixed(2);
    price = Number(price);
    let updatedAd = {
        title: $('#formEditAd input[name=title]').val(),
        description: $('#formEditAd textarea[name=description]').val(),
        publisher: $('#formEditAd input[name=publisher]').val(),
        dateCreated: dateCreated,
        price: price,
        image: $('#formEditAd input[name=image]').val()
    };

    let updateAddRequest = {
        method: 'PUT',
        url: `${kinveyBaseUrl}/appdata/${kinveyAppKey}/adverts/${adId}`,
        headers: {
            'Authorization': `Kinvey ${sessionStorage.getItem('authToken')}`,
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(updatedAd),
        success: listAds,
        error: handleAjaxError
    };

    $.ajax(updateAddRequest)
        .then(() => {
            showInfoBox('Ad edited successfully');
        });
}

function createAd () {
    let title = $('#formCreateAd input[name=title]').val();
    let description = $('#formCreateAd textarea[name=description]').val();
    let publisher = sessionStorage.getItem('username');
    let dateInfo = $('#formCreateAd input[name=datePublished]').val().split('-');
    let dateCreated = `${dateInfo[1]}/${dateInfo[2]}/${dateInfo[0]}`;
    let price = Number($('#formCreateAd input[name=price]').val()).toFixed(2);
    price = Number(price);
    let image = $('#formCreateAd input[name=image]').val();
    let newAd = {
        title: title,
        description: description,
        publisher: publisher,
        dateCreated: dateCreated,
        price: price,
        image: image,
        views: 0
    };

    let createAdRequest = {
        method: 'POST',
        url: `${kinveyBaseUrl}/appdata/${kinveyAppKey}/adverts`,
        headers: {
            'Authorization': `Kinvey ${sessionStorage.getItem('authToken')}`,
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(newAd),
        success: listAds,
        error: handleAjaxError
    };

    $.ajax(createAdRequest)
       .then(() => {
            showInfoBox('Ad created successfully');
        });
}

function loginUser () {
    let userData = {
        username: $('#formLogin input[name=username]').val(),
        password: $('#formLogin input[name=password]').val()
    };

    let loginUserRequest = {
        method: 'POST',
        url: `${kinveyBaseUrl}/user/${kinveyAppKey}/login`,
        headers: kinveyAppAuthHeaders,
        data: JSON.stringify(userData),
        success: loginSuccess,
        error: handleAjaxError
    };

    $.ajax(loginUserRequest);
}

function loginSuccess (userInfo) {
    saveAuthInSession(userInfo);
    showHideMenuLinks();
    showHomeView();
    showInfoBox('You are now logged in');
}

function registerUser () {
    let userData = {
        username: $('#formRegister input[name=username]').val(),
        password: $('#formRegister input[name=password]').val()
    };

    let registerUserRequest = {
        method: 'POST',
        url: `${kinveyBaseUrl}/user/${kinveyAppKey}`,
        headers: kinveyAppAuthHeaders,
        data: JSON.stringify(userData),
        success: registerSuccess,
        error: handleAjaxError
    };

    $.ajax(registerUserRequest)
        .then(() => {
            showInfoBox('Regsitered successfully');
        });
}

function registerSuccess (userInfo) {
    saveAuthInSession(userInfo);
    showHideMenuLinks();
    showHomeView();
    // showInfo('User registration successful.');
}

function saveAuthInSession (userInfo) {
    sessionStorage.setItem('authToken', userInfo._kmd.authtoken);
    sessionStorage.setItem('userId', userInfo._id);
    sessionStorage.setItem('username', userInfo.username);
}

function attachMenuLinksEvents () {
    $('#linkHome').click(showHomeView);
    $('#linkLogin').click(showLoginView);
    $('#linkRegister').click(showRegisterView);
    $('#linkListAds').click(listAds);
    $('#linkCreateAd').click(showCreateAdView);
    $('#linkLogout').click(logoutUser);
}

function listAds () {
    $('#ads').empty();
    let authToken = sessionStorage.getItem('authToken');
    let getAdsRequest = {
        method: 'GET',
        url: `${kinveyBaseUrl}/appdata/${kinveyAppKey}/adverts`,
        headers: {
            'Authorization': `Kinvey ${authToken}`,
            'Content-Type': 'application/json'
        },
        success: displayAds,
        error: handleAjaxError
    };

    $.ajax(getAdsRequest);
}

function displayAds (ads) {
    let table = $(`<table>
                        <tr>
                            <th>Title</th>
                            <th>Publisher</th>
                            <th>Description</th>
                            <th>Price</th>
                            <th>Date Published</th>
                            <th>Actions</th>
                        </tr>
                    </table>`);

    let userId = sessionStorage.getItem('userId');
    for (let ad of ads) {
        let tr = $('<tr>');
        let titleTd = $('<td>').text(ad.title);
        let publisherTd = $('<td>').text(ad.publisher);
        let descriptionTd = $('<td>').text(ad.description);
        let priceTd = $('<td>').text(ad.price);
        let datePublishedTd = $('<td>').text(ad.dateCreated);
        let moreDetailsLink = $(`<a href="#" data-ad-id="${ad._id}" class="read-more-btn">[Read More] </a>`);
        let actionsTd = $('<td>');
        actionsTd.append(moreDetailsLink);
        tr.append(titleTd)
            .append(publisherTd)
            .append(descriptionTd)
            .append(priceTd)
            .append(datePublishedTd);
        
        if (ad._acl.creator === userId) {
            let deleteButton = $(`<a href="#" class="delete-ad-btn" data-ad-id="${ad._id}"></a>`).text('[Delete] ');
            let editButton = $(`<a href="#" class="edit-ad-btn" data-ad-id="${ad._id}"></a>`).text('[Edit]');
            actionsTd.append(deleteButton).append(editButton);
        }

        tr.append(actionsTd);
        table.append(tr);
    }

    $('#ads').append(table);
    attachAdsButtonsEvents();
    showListAdsView();
}

function attachAdsButtonsEvents () {
    $('.delete-ad-btn').click(deleteAd);
    $('.edit-ad-btn').click(getAdInfo);
    $('.read-more-btn').click(getAdDetails);
}

function getAdDetails (event) {
    let adId = $(event.currentTarget).attr('data-ad-id');
        console.log(adId);
    let getAdDetailsRequest = {
        method: 'GET',
        url: `${kinveyBaseUrl}/appdata/${kinveyAppKey}/adverts/${adId}`,
        headers: {
            'Authorization': `Kinvey ${sessionStorage.getItem('authToken')}`
        },
        success: displayAdDetails,
        error: handleAjaxError
    };

    $.ajax(getAdDetailsRequest);
}

function displayAdDetails (ad) {
    $('#viewDetailsAd').empty();

    let adInfo = $('<div>').append(
        $(`<img src="${ad.image}" width="100" height="100">`),
        $('<br>'),
        $('<label>').text('Title:'),
        $('<h1>').text(ad.title),
        $('<label>').text('Description:'),
        $('<p>').text(ad.description),
        $('<label>').text('Publisher:'),
        $('<div>').text(ad.publisher),
        $('<label>').text('Date:'),
        $('<div>').text(ad.dateCreated),
        $('<label>').text('Views:'),
        $('<div>').text(ad.views)
    );

     $('#viewDetailsAd').append(adInfo);
     showAdDetailsView();
}

function displayAdInEditForm (adInfo) {
    $('#formEditAd input[name=id]').val(adInfo._id);
    $('#formEditAd input[name=title]').val(adInfo.title);
    $('#formEditAd textarea[name=description]').val(adInfo.description);
    $('#formEditAd input[name=publisher]').val(adInfo.publisher);
    let datePublished = new Date(adInfo.dateCreated);
    datePublished.setDate(datePublished.getDate() + 1);
    $('#formEditAd input[name=datePublished]').val(datePublished.toISOString().substr(0, 10));
    $('#formEditAd input[name=price]').val(adInfo.price);
       $('#formEditAd input[name=image]').val(adInfo.image);

    showEditAdView();
}

function getAdInfo (event) {
    let adId = $(event.currentTarget).attr('data-ad-id');
    let getAdRequest = {
        method: 'GET',
        url: `${kinveyBaseUrl}/appdata/${kinveyAppKey}/adverts/${adId}`,
        headers: {
            'Authorization': `Kinvey ${sessionStorage.getItem('authToken')}`
        },
        success: displayAdInEditForm,
        error: handleAjaxError
    };

    $.ajax(getAdRequest);
}

function deleteAd (event) {
    let adId = $(event.currentTarget).attr('data-ad-id');
    
    let deleteAdRequest = {
        method: 'DELETE',
        url: `${kinveyBaseUrl}/appdata/${kinveyAppKey}/adverts/${adId}`,
        headers: {
            'Authorization': `Kinvey ${sessionStorage.getItem('authToken')}`
        },
        success: listAds,
        error: handleAjaxError
    };

    $.ajax(deleteAdRequest)
        .then(() => {
            showInfoBox('Ad deleted successfully');
        });
}

function showView (viewName) {
    $('main > section').hide();
    $(`#${viewName}`).show();
}

function showHomeView () {
    showView('viewHome');
}

function showLoginView () {
    showView('viewLogin');
}

function showRegisterView () {
    showView('viewRegister');
}

function showListAdsView () {
    showView('viewAds');
}

function showCreateAdView () {
    showView('viewCreateAd');
}

function showEditAdView () {
    showView('viewEditAd');
}

function showAdDetailsView () {
    showView('viewDetailsAd');
}

function showHideMenuLinks () {
    if (sessionStorage.getItem('authToken')) {
        // Logged in user
        $('#linkHome').show();
        $('#linkLogin').hide();
        $('#linkRegister').hide();
        $('#linkListAds').show();
        $('#linkCreateAd').show();
        $('#linkLogout').show();
    } else {
        // Not logged in user
        $('#linkHome').show();
        $('#linkLogin').show();
        $('#linkRegister').show();
        $('#linkListAds').hide();
        $('#linkCreateAd').hide();
        $('#linkLogout').hide();
    }
}

function handleAjaxError (response) {
     let errorMsg = JSON.stringify(response);

    if (response.readyState === 0) {
        errorMsg = 'Cannot connect due to network error.';
    }

    if (response.responseJSON && response.responseJSON.description) {
        errorMsg = response.responseJSON.description;
    }

    showError(errorMsg);
}

function logoutUser () {
    sessionStorage.clear();
    showHideMenuLinks();
    showHomeView();
}

function showInfoBox (message) {
    $('#infoBox').text(message).show().fadeOut(3000);
}

function showError(message) {
     $('#errorBox').text(message).show().click(() => {
         $('#errorBox').hide();
     });
}
