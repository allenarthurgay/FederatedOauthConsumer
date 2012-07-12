using System;
using System.Collections.Generic;
using Api.Contracts.Repositories;
using Api.Contracts.Services;
using Api.Contracts.dto;
using Data;

namespace Api.Implementations.Services
{
	public class AuthConsumerService : IAuthConsumerService
	{
		private readonly IUserTokenRepository _userTokenRepository;
		private readonly IServiceProviderHtmlFactory _serviceProviderHtmlFactory;
		private readonly IServiceProviderRepository _serviceProviderRepository;
		private readonly IAuthTokenMassagerServiceFactory _authTokenMassagerServiceFactory;

		public AuthConsumerService(IUserTokenRepository userTokenRepository,
			IServiceProviderRepository serviceProviderRepository,
			IServiceProviderHtmlFactory serviceProviderHtmlFactory,
			IAuthTokenMassagerServiceFactory authTokenMassagerServiceFactory)
		{
			_userTokenRepository = userTokenRepository;
			_serviceProviderHtmlFactory = serviceProviderHtmlFactory;
			_serviceProviderRepository = serviceProviderRepository;
			_authTokenMassagerServiceFactory = authTokenMassagerServiceFactory;
		}

		public GetSupportedServicesResponse GetSupportedServices(GetSupportedServicesRequest request)
		{
			return new GetSupportedServicesResponse { SupportedServices = _serviceProviderRepository.GetSupportedServices() };
		}

		public IsRegisteredForServiceResponse IsRegisteredForService(IsRegisteredForServiceRequest request)
		{
			if(!_serviceProviderRepository.GetSupportedServices().Contains(request.Service.ToLower()))
			{
				return new IsRegisteredForServiceResponse
						{
							IsRegistered =false
						};
			}

			var service = _serviceProviderRepository.GetByServiceName(request.Service);
			var token = _userTokenRepository.GetUserTokenRecord(request.PrincipalId, service.Name);
									
			return new IsRegisteredForServiceResponse {IsRegistered = token != null && !string.IsNullOrEmpty(token.Token)};
		}

		public GetRegistrationHtmlResponse GetRegistrationHtml(GetRegistrationHtmlRequest request)
		{
			var service = _serviceProviderRepository.GetByServiceName(request.Service);
			var htmlProvider = _serviceProviderHtmlFactory.GetProviderHtmlService(service);

			var html = string.Empty;
			if(null != htmlProvider)
			{
				html = htmlProvider.GetHtmlForService(service);
			}

			return new GetRegistrationHtmlResponse {Html = html};
		}

		public GetServiceTokenForPrincipalIdResponse GetServiceTokenForPrincipalId(GetServiceTokenForPrincipalIdRequest request)
		{
			var service = _serviceProviderRepository.GetByServiceName(request.Service);
			var token = _userTokenRepository.GetUserTokenRecord(request.PrincipalId, service.Name);

			return new GetServiceTokenForPrincipalIdResponse { Token = token == null ? string.Empty : token.Token };

		}

		public void RegisterServiceToken(RegisterServiceTokenRequest request)
		{
			//does already exist
			var service = _serviceProviderRepository.GetByServiceName(request.Service);
			var token = _userTokenRepository.GetUserTokenRecord(request.PrincipalId, service.Name);
			var massager = _authTokenMassagerServiceFactory.GetMassagerForService(service);
			var authToken = massager == null ? request.Token : massager.NormalizeToken(request.Token);

			if(token ==  null)
			{
				_userTokenRepository.Add(new UserTokenRecord
											 {
												 UniqueId = new Guid(),
												 UserId = request.PrincipalId,
												 ServiceType = request.Service,
												 Token = authToken,
												 Created = DateTime.Now,
												 Updated = DateTime.Now,
												 Status = 1
											 });
			}
			else
			{
				token.Updated = DateTime.Now;
				token.Token = authToken;
				_userTokenRepository.Edit(token);
			}
		}
	}
}
