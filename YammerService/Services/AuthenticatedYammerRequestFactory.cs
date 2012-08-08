using System;
using System.Net;
using Api.RestServiceHost.Handlers;

namespace Api.RestServiceHost.Services
{
    public class AuthenticatedYammerRequestFactory : IAuthenticatedYammerRequestFactory
    {
        private readonly IUserAuthTokenRepository _userAuthTokenRepository;

        public AuthenticatedYammerRequestFactory(IUserAuthTokenRepository userAuthTokenRepository)
        {
            _userAuthTokenRepository = userAuthTokenRepository;
        }

        public HttpWebRequest CreateAuthenticatedRequest(string principalId, string url)
        {
            var userToken = _userAuthTokenRepository.GetUserTokenForPrincipalId(principalId,
                                                                                GlobalSettings.YammerServiceName);

            if (string.IsNullOrEmpty(userToken))
            {
                throw new Exception("Couldn't find authorization for principalid:" + principalId +
                                    "for service" + GlobalSettings.YammerServiceName);
            }
            var webRequest = (HttpWebRequest)WebRequest.Create(url);

            webRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + userToken);

            return webRequest;
        }
    }
}