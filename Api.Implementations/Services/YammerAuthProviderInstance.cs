using Api.Contracts.Services;
using Api.Contracts.dto;
using Data;

namespace Api.Implementations.Services
{
    public class YammerAuthProviderInstance : IAuthProviderInstance
    {
        public ServiceProvider SupportedService
        {
            get
            {
                return new ServiceProvider
                    {
                        Name = "yammer"
                    };
            }
        }

        public string NormalizeToken(string serviceAuthToken)
        {
            return serviceAuthToken;
        }

        public GetRegistrationHtmlResponse GetHtmlForService(string userId, string applicationId)
        {
            return new GetRegistrationHtmlResponse
            {
                AppId = applicationId,//"Fr2MmPLjRBjIePWG9kxH8A",
                PrincipalId = userId,
                Service = SupportedService.Name,
                ScriptUrlRoot = "/script",
                Html = "<script type=\"text/javascript\" src=\"/Script/authservices.js\"></script>"
            };
        }
    }
}
