using Api.Contracts.Dto;
using Data;

namespace Api.Contracts.Services
{
	public interface IAuthProviderInstance
	{
		ServiceProvider SupportedService { get; }

		/// <summary>
		///this allows a 3rd parth auth provider the opportunity to take the "Token" string, parse it into a DTO,
		///and then serialize it into a normalized string
		/// </summary>
		/// <param name="serviceAuthToken"></param>
		/// <returns></returns>
		string NormalizeToken(string serviceAuthToken);

        GetRegistrationHtmlResponse GetHtmlForService(string userId, string applicationId);	   
	}
}
