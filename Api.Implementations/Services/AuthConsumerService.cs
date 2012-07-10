using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Contracts.Services;
using Api.Contracts.dto;

namespace Api.Implementations.Services
{
	public class AuthConsumerService : IAuthConsumerService
	{
		public GetSupportedServicesResponse GetSupportedServices(GetSupportedServicesRequest request)
		{
			return new GetSupportedServicesResponse {SupportedServices = new List<string> {"twitter"}};
		}

		public IsRegisteredForServiceResponse IsRegisteredForService(IsRegisteredForServiceRequest request)
		{
			//todo actuall go get data
			return new IsRegisteredForServiceResponse {IsRegistered = true};
		}

		public GetRegistrationHtmlResponse GetRegistrationHtml(GetRegistrationHtmlRequest request)
		{
			return new GetRegistrationHtmlResponse
			       	{
						Html = @"<img src=""https://si0.twimg.com/images/dev/buttons/sign-in-with-twitter-d.png"" />"
					};
		}

		public GetServiceTokenForPrincipalIdResponse GetServiceTokenForPrincipalId(GetServiceTokenForPrincipalIdRequest request)
		{
			// todo actually go get the data
			return new GetServiceTokenForPrincipalIdResponse {Token = "abc123"};
		}
	}
}
