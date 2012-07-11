using Api.Contracts.dto;

namespace Api.Contracts.Services
{
	public interface IAuthConsumerService
	{
		GetSupportedServicesResponse GetSupportedServices(GetSupportedServicesRequest request);
		IsRegisteredForServiceResponse IsRegisteredForService(IsRegisteredForServiceRequest request);
		GetRegistrationHtmlResponse GetRegistrationHtml(GetRegistrationHtmlRequest request);
		GetServiceTokenForPrincipalIdResponse GetServiceTokenForPrincipalId(GetServiceTokenForPrincipalIdRequest request);
		void RegisterServiceToken(RegisterServiceTokenRequest request);
	}
}
