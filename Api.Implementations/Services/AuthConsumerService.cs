using System;
using Api.Contracts.Repositories;
using Api.Contracts.Services;
using Api.Contracts.dto;
using Data;


namespace Api.Implementations.Services
{
	public class AuthConsumerService : IAuthConsumerService
	{
		private readonly IUserTokenRepository _userTokenRepository;
		private readonly IAuthProviderFactory _authProviderFactory;
		private readonly IServiceProviderRepository _serviceProviderRepository;
		

		public AuthConsumerService(IUserTokenRepository userTokenRepository,
			IServiceProviderRepository serviceProviderRepository,
			IAuthProviderFactory authProviderFactory)
		{
			_userTokenRepository = userTokenRepository;
			_authProviderFactory = authProviderFactory;
			_serviceProviderRepository = serviceProviderRepository;
		}

		public GetSupportedServicesResponse GetSupportedServices(GetSupportedServicesRequest request)
		{
			return new GetSupportedServicesResponse { SupportedServices = _serviceProviderRepository.GetSupportedServices() };
		}

		public IsRegisteredForServiceResponse IsRegisteredForService(IsRegisteredForServiceRequest request)
		{
			var service = _serviceProviderRepository.GetByServiceName(request.Service);
			var token = _userTokenRepository.GetUserTokenRecord(request.PrincipalId, service.Id);
									
			return new IsRegisteredForServiceResponse {IsRegistered = token != null && !string.IsNullOrEmpty(token.Token)};
		}

		public GetRegistrationHtmlResponse GetRegistrationHtml(GetRegistrationHtmlRequest request)
		{
			var service = _serviceProviderRepository.GetByServiceName(request.Service);
			var authProvider = _authProviderFactory.GetAuthProviderInstance(service);

			var html = string.Empty;
			if (null != authProvider)
			{
                return authProvider.GetHtmlForService(request.PrincipalId.ToString(), request.ApplicationId);
			}

			return new GetRegistrationHtmlResponse();
		}

		public GetServiceTokenForPrincipalIdResponse GetServiceTokenForPrincipalId(GetServiceTokenForPrincipalIdRequest request)
		{
			var service = _serviceProviderRepository.GetByServiceName(request.Service);
			var token = _userTokenRepository.GetUserTokenRecord(request.PrincipalId, service.Id);

			return new GetServiceTokenForPrincipalIdResponse { Token = token == null ? string.Empty : token.Token };

		}

		public void RegisterServiceToken(RegisterServiceTokenRequest request)
		{
			//does already exist
			var service = _serviceProviderRepository.GetByServiceName(request.Service);
			var token = _userTokenRepository.GetUserTokenRecord(request.PrincipalId, service.Id);
			var authProvider = _authProviderFactory.GetAuthProviderInstance(service);
			var authToken = authProvider == null ? request.Token : authProvider.NormalizeToken(request.Token);

			if(token ==  null)
			{
				_userTokenRepository.Add(new UserTokenRecord
											 {
												 UniqueId = new Guid(),
												 UserId = request.PrincipalId,
												 ServiceTypeId = service.Id,
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

	    public void RegisterServiceProvider(RegisterServiceProviderRequest request)
	    {
	        _serviceProviderRepository.AddServiceProvider(request.Name);
	    }
	}
}
