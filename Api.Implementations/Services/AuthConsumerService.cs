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
			return new GetSupportedServicesResponse {SupportedServices = new List<string> {"facebook","twitter"}};
		}

		public IsRegisteredForServiceResponse IsRegisteredForService(IsRegisteredForServiceRequest request)
		{
            var token = _userTokenRepository.GetUserTokenRecord(request.PrincipalId, request.Service);
            			            
			return new IsRegisteredForServiceResponse {IsRegistered = string.IsNullOrEmpty(token.Token)};
		}

		public GetRegistrationHtmlResponse GetRegistrationHtml(GetRegistrationHtmlRequest request)
		{
		    var service = _serviceProviderRepository.GetByServiceName(request.Service);
		    var htmlProvider = _serviceProviderHtmlFactory.GetProviderHtmlService(service);

            if(null == htmlProvider)
            {
                throw  new Exception("Couldn't find an html provider for service named :" + request.Service);
            }
		    
			return new GetRegistrationHtmlResponse
			       	{
						Html =htmlProvider.GetHtmlForService(service)
					};
		}

		public GetServiceTokenForPrincipalIdResponse GetServiceTokenForPrincipalId(GetServiceTokenForPrincipalIdRequest request)
		{
			// todo actually go get the data
			return new GetServiceTokenForPrincipalIdResponse {Token = "abc123"};

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
