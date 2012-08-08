using ServiceStack.ServiceClient.Web;

namespace Api.RestServiceHost.Services
{
    public class FASTUserAuthTokenRepository:IUserAuthTokenRepository
    {
        private readonly JsonServiceClient _serviceClient;
        private readonly string _apiUrl = "/{0}/{1}/gettoken";

        public FASTUserAuthTokenRepository(JsonServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }
        public string GetUserTokenForPrincipalId(string principalId, string serviceName)
        {
            var response = _serviceClient.Get<UserTokenResponse>(GetUrlForToken(principalId, serviceName));
            return response.Token;
        }

        private string GetUrlForToken(string principalId, string serviceName)
        {
            return string.Format(_apiUrl, principalId, serviceName);
        }
    }
}