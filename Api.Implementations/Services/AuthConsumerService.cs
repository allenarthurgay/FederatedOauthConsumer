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
	}
}
