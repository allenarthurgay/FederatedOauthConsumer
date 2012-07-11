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

	    public AuthConsumerService(IUserTokenRepository userTokenRepository)
        {
            _userTokenRepository = userTokenRepository;
        }

		public GetSupportedServicesResponse GetSupportedServices(GetSupportedServicesRequest request)
		{
			return new GetSupportedServicesResponse {SupportedServices = new List<string> {"twitter"}};
		}

		public IsRegisteredForServiceResponse IsRegisteredForService(IsRegisteredForServiceRequest request)
		{
            var token = _userTokenRepository.GetUserTokenRecord(request.PrincipalId, request.Service);
            			
			return new IsRegisteredForServiceResponse {IsRegistered = token != null};
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

		public void RegisterServiceToken(RegisterServiceTokenRequest request)
		{
			//does already exist
		    var token = _userTokenRepository.GetUserTokenRecord(request.PrincipalId, request.Service);
            if(token ==  null)
            {
                _userTokenRepository.Add(new UserTokenRecord
                                             {
                                                 UserId = request.PrincipalId,
                                                 ServiceType = request.Service
                                             });
            }
            else
            {
                token.Updated = DateTime.Now;
                token.Token = request.Token;
                _userTokenRepository.Edit(token);
            }
		}
	}
}
