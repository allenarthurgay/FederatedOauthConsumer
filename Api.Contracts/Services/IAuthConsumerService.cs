using Api.Contracts.dto;

namespace Api.Contracts.Services
{
	public interface IAuthConsumerService
	{
		GetSupportedServicesResponse GetSupportedServices(GetSupportedServicesRequest request);
		GetRegistrationHtmlResponse GetRegistrationHtml(GetRegistrationHtmlRequest request);
	}
}
