function yammer_auth() {
    yam.config({ appId: AuthApiConfig.appId });
    yam.getLoginStatus(function (response) {
        if (response.authResponse) {
            yammer_register(response.access_token.token);  
        } else {
            yam.login(function (response) {
                if (response.success) {
                    yammer_register(response.access_token.token);                   
                } else {
                    // user cancelled login
                    // failed to log user in.. do something else... murder robots...
                    alert('Failed to login');
                }
            });
        }
    });
}

function yammer_register(authtoken) {
    var urlToSendCredentials = "/register/token";

    var dataToPost = {
        principalId: AuthApiConfig.principalId,
        service: AuthApiConfig.service,
        token: authtoken
    };
    $.post(urlToSendCredentials, dataToPost, function (data) {
        window.location.reload();
    }); 
}
(function () {
    async_addScript(document, 'yammer-jssdk', "//assets.yammer.com/platform/yam.js");
    async_addScript(document, 'jquery', "//ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js");
})();