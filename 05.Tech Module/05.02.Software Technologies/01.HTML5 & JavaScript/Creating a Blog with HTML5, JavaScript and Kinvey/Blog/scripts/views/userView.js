class UserView{
    constructor(wrapperSelector, mainContentSelector){
        this._wrapperSelector = wrapperSelector;
        this._mainContentSlector = mainContentSelector;
    }

    showLoginPage(isLoggedIn){
        let _that = this;
        let templateUrl;

        if (isLoggedIn){
            templateUrl = "templates/form-user.html";
        }
        else {
            templateUrl = "templates/form-guest.html";
        }

        $.get(templateUrl, function (template) {
            let renderedWrapper = Mustache.render(template, null);

            $(_that._wrapperSelector).html(renderedWrapper);

            $.get('templates/login.html', function (template) {
                let rendered = Mustache.render(template, null);
                $(_that._mainContentSlector).html(rendered);
                
                $('#login-request-button').on('click', function () {
                    let username = $('#username').val();
                    let password = $('#password').val();
                    
                    let data = {
                        username: username,
                        password: password
                    };
                    
                    triggerEvent('login', data);
                });
            });
        });
    }

    showRegisterPage(isLoggedIn){
        let that = this;
        let templateUrl;

        if (isLoggedIn){
            templateUrl = "templates/form-user.html";
        }
        else{
            templateUrl = "templates/form-guest.html";
        }

        $.get(templateUrl, function (template) {
            let renderedWrapper = Mustache.render(template, null);
            $(that._wrapperSelector).html(renderedWrapper);

            $.get('templates/register.html', function (template) {
                let rendered = Mustache.render(template, null);
                $(that._mainContentSlector).html(rendered);

                $('#register-request-button').on('click', function (ev) {
                    let username = $('#username').val();
                    let password = $('#password').val();
                    let confirmPassword = $('#pass-confirm').val();
                    let fullName = $('#full-name').val();
11
                    let data = {
                        username: username,
                        password: password,
                        confirmPassword: confirmPassword,
                        fullName: fullName
                    };

                    triggerEvent('register', data);
                });
            });
        });
    }
}