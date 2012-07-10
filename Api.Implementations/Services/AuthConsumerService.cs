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

		public GetRegistrationHtmlResponse GetRegistrationHtml(GetRegistrationHtmlRequest request)
		{
			return new GetRegistrationHtmlResponse
			       	{
						Html = @"<img src=""https://si0.twimg.com/images/dev/buttons/sign-in-with-twitter-d.png"" />"
					};
		}
	}
}
