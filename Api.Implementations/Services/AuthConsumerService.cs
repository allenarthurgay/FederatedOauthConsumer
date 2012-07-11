using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Contracts.Services;
using Api.Contracts.dto;
using Data;

namespace Api.Implementations.Services
{
	public class AuthConsumerService : IAuthConsumerService
	{
		readonly ServiceProviderRepository _serviceProviderRepo = new ServiceProviderRepository();
		readonly UserTokenRecordRepository _userTokenRecordRepo = new UserTokenRecordRepository();

		public GetSupportedServicesResponse GetSupportedServices(GetSupportedServicesRequest request)
		{
			var providers = _serviceProviderRepo.GetAll().ToList();
			var services = providers.Select(serviceProvider => serviceProvider.Name).ToList();

			return new GetSupportedServicesResponse
			       	{
			       		SupportedServices = services
			       	};


			//return new GetSupportedServicesResponse
			//        {
			//            SupportedServices = new List<string> {"twitter"}
			//        };
		}

		public IsRegisteredForServiceResponse IsRegisteredForService(IsRegisteredForServiceRequest request)
		{
			return new IsRegisteredForServiceResponse { IsRegistered = GetRecord(request.PrincipalId, request.Service) != null };
			//return new IsRegisteredForServiceResponse {IsRegistered = true};
		}

		public GetRegistrationHtmlResponse GetRegistrationHtml(GetRegistrationHtmlRequest request)
		{
			return new GetRegistrationHtmlResponse
			       	{
			       		Html = @"<img src=""https://si0.twimg.com/images/dev/buttons/sign-in-with-twitter-d.png"" />"
			       	};
		}

		public GetServiceTokenForPrincipalIdResponse GetServiceTokenForPrincipalId(
			GetServiceTokenForPrincipalIdRequest request)
		{
			return new GetServiceTokenForPrincipalIdResponse
			       	{
			       		Token = GetRecord(request.PrincipalId, request.Service).Token
			       	};


			//// todo actually go get the data
			//return new GetServiceTokenForPrincipalIdResponse {Token = "abc123"};
		}

		private UserTokenRecord GetRecord(Guid userId, string service)
		{
			return _userTokenRecordRepo.GetUserTokenRecord(userId, service);
		}
	}
}