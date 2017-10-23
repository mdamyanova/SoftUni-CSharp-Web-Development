(function () {
    let baseUrl = "https://baas.kinvey.com";
    let appKey = "kid_ry4lBWsH";
    let appSecret = "9368b63a8d2c4babb9137facfd9a5c14";
    var _guestCredentials = "c9c1ae6d-a42d-473c-b7d1-5e49a80c773a.xknMq1PKYNOzOoVYn1auOMVc9/vy4GBI4oi2zlQyLKY=";

    let authService = new AuthorizationService(
        baseUrl,
        appKey,
        appSecret,
        _guestCredentials
    );
    authService.initAuthorizationType("Kinvey");
    let requester = new Requester(authService);

    let selector = ".wrapper";
    let mainContentSelector = ".main-content";

    let homeView = new HomeView(selector, mainContentSelector);
    let homeController = new HomeController(homeView, requester, baseUrl, appKey);

    let userView = new UserView(selector, mainContentSelector);
    let userController = new UserController(userView, requester, baseUrl, appKey);
    
    let postView = new PostView(selector, mainContentSelector);
    let postController = new PostController(postView, requester, baseUrl, appKey);

    initEventServices();

    onRoute("#/",
        function () {
        if (authService.isLoggedIn()){
            homeController.showUserPage();
        }
        else{
            homeController.showGuestPage();
        }
    });

    onRoute("#/post-:id", function () {
       let top = $("#post-" + this.params['id'])
           .position().top;
        $(window).scrollTop(top);
    });

    onRoute("#/login", function () {
        userController.showLoginPage(authService.isLoggedIn());
    });

    onRoute("#/register", function () {
        userController.showRegisterPage(authService.isLoggedIn());
    });

    onRoute("#/logout", function () {
        userController.logout();
    });

    onRoute('#/posts/create', function () {
        let data ={
            fullName: sessionStorage['fullName']
        };
        postController.showCreatePostPage(data, authService.isLoggedIn());
    });

    bindEventHandler('login', function (ev, data) {
        userController.login(data);
    });

    bindEventHandler('register', function (ev, data) {
        userController.register(data);
    });

    bindEventHandler('createPost', function (ev, data) {
        postController.createNewPost(data);
    });

    run('#/');
})();
