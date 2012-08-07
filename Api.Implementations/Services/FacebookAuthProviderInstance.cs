using Api.Contracts.Services;
using Data;

namespace Api.Implementations.Services
{
	public class FacebookAuthProviderInstance: IAuthProviderInstance
	{
		public ServiceProvider SupportedService
		{
			get
			{
				return new ServiceProvider
				       	{
				       		Name = "Facebook"
				       	};
			}
		}

		public string NormalizeToken(string serviceAuthToken)
		{
			return serviceAuthToken;
		}

		public string GetHtmlForService(ServiceProvider provider)
		{
			return @"<div id=""fb-root""></div><div id=""user-info""></div><button id=""fb-auth""></button>
<script>
window.fbAsyncInit = function() {
		$('html').attr('xmlns:fb','https://www.facebook.com/2008/fbml');
		FB.init({ appId: '352351538166944',
			status: true,
			cookie: true,
			xfbml: true,
			oauth: true});
 
		showLoader(true);
 
		function updateButton(response) {
			button       =   document.getElementById('fb-auth');
			userInfo     =   document.getElementById('user-info');
 
			if (response.authResponse) {
				//user is already logged in and connected
				FB.api('/me', function(info) {
					login(response, info);
				});
 
				button.onclick = function() {
					FB.logout(function(response) {
						logout(response);
					});
				};
			} else {
				//user is not connected to your app or logged out
				button.innerHTML = 'Login';
				button.onclick = function() {
					showLoader(true);
					FB.login(function(response) {
						if (response.authResponse) {
							FB.api('/me', function(info) {
								login(response, info);
							});
						} else {
							//user cancelled login or did not grant authorization
							showLoader(false);
						}
					}, {scope:'email,user_birthday,status_update,publish_stream,user_about_me'});
				}
			}
		}
 
		// run once with current status and whenever the status changes
		FB.getLoginStatus(updateButton);
		FB.Event.subscribe('auth.statusChange', updateButton);
	};
	(function() {
		var e = document.createElement('script'); e.async = true;
		e.src = document.location.protocol
			+ '//connect.facebook.net/en_US/all.js';
		document.getElementById('fb-root').appendChild(e);
	}());
</script>
";
		}

	}
}
