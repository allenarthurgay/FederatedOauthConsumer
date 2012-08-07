function fb_auth() {
	FB.login(function (response) {
		if (response.status == "connected") {
			var fb = FB.getAuthResponse();
			var urlToSendCredentials = "/register/token";

			var dataToPost = {
				principalId: AuthApiConfig.principalId,
				service: AuthApiConfig.service,
				token: fb.accessToken
			};
			$.post(urlToSendCredentials, dataToPost, function (data) {
				window.location.reload();
			});
		}
		else {
			console.log('User cancelled login or did not fully authorize.');
		}
	}, { scope: "offline_access" });
}

(function () {
	async_addScript(document, 'facebook-jssdk', "//connect.facebook.net/en_US/all.js#xfbml=1&appId=" + AuthApiConfig.appId);
	async_addScript(document, 'jquery', "//ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js");
})();