using Api.Contracts.Services;
using Api.Contracts.dto;
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
				       		Name = "facebook"
				       	};
			}
		}

		public string NormalizeToken(string serviceAuthToken)
		{
			return serviceAuthToken;
		}

        public GetRegistrationHtmlResponse GetHtmlForService(string userId)
        {
            return new GetRegistrationHtmlResponse
                {
                    AppId = "352351538166944",
                    PrincipalId = userId,
                    Service = SupportedService.Name,
                    ScriptUrlRoot = "/script",
                    Html = "<script type=\"text/javascript\" src=\"/Script/authservices.js\"></script>"
                };
          // return "<script type=\"text/javascript\">" +
          //                     "var AuthApiConfig = {appId: \"352351538166944\", principalId: \"" + userId + "\",service: \"" + SupportedService.Name + "\",scriptUrlRoot: \"/script\"};" +
          //                     "</script><script type=\"text/javascript\" src=\"/script/authservices.js\"></script>";
            
		}

	}
}
