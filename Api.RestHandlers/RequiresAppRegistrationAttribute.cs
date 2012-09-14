using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Api.Contracts.Dto;
using Api.Contracts.Repositories;
using Api.Contracts.Services;
using ServiceStack.Logging;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers
{
	[AttributeUsage(AttributeTargets.Class)]
	public class RequiresAppRegistrationAttribute: RequestFilterAttribute
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(RequiresAppRegistrationAttribute));

		public IApplicationAuthenticationService ApplicationAuthenticationService { get; set; }
		public IApplicationRepository ApplicationRepository { get; set; }
		public IAccountApplicationRepository AccountApplicationRepository { get; set; }

		public override void Execute(IHttpRequest req, IHttpResponse res, object requestDto)
		{
			var applicationRequest = requestDto as ApplicationRequest;
			var appKey = GetAppKeyFromRequest(req, applicationRequest);
			var appSecret = GetAppSecretFromRequest(req, applicationRequest);

			var app = ApplicationAuthenticationService.Authenticate(appKey,appSecret);
			if (app == null)
			{
				res.StatusCode = (int)HttpStatusCode.Forbidden;
				// Some Android devices require a body, otherwise the response code is ignored and set 0
				res.Write(HttpStatusCode.Forbidden.ToString());
				res.Close();
			}
			if (applicationRequest != null)
			{
				applicationRequest.AppKey = appKey;
				applicationRequest.AppSecret = appSecret;
				applicationRequest.Application = ApplicationRepository.FindApplication(appKey, appSecret);
				applicationRequest.Account = AccountApplicationRepository.GetForApplication(applicationRequest.Application.Id);
			}
			var validationErrors = ValidateRequest(applicationRequest);
			if (validationErrors.Any())
			{
				res.StatusCode = (int)HttpStatusCode.BadRequest;
				// Some Android devices require a body, otherwise the response code is ignored and set 0
				res.Write(HttpStatusCode.BadRequest.ToString());
				foreach (var error in validationErrors)
				{
					res.Write(error);
				}
				res.Close();
			}
		}

		private IEnumerable<string> ValidateRequest(ApplicationRequest applicationRequest)
		{
			var errors = new List<string>();
			if(string.IsNullOrEmpty(applicationRequest.AppKey))
			{
				errors.Add("AppKey is empty");
			}
			if (string.IsNullOrEmpty(applicationRequest.AppSecret))
			{
				errors.Add("AppSecret is empty");
			}
			if(applicationRequest.Account == null)
			{
				errors.Add("Account couldn't be found");
			}
			if (applicationRequest.Application == null)
			{
				errors.Add("Application couldn't be found");
			}
			return errors;
		}

		private string GetAppSecretFromRequest(IHttpRequest httpRequest, ApplicationRequest requestDto)
		{
			string secret = httpRequest.Headers[ApiRegistration.AppSecretHeader];

			if (string.IsNullOrEmpty(secret) && requestDto != null)
			{
				secret = requestDto.AppSecret;
			}

			return secret;
		}

		private string GetAppKeyFromRequest(IHttpRequest httpRequest, ApplicationRequest requestDto)
		{
			string apiKey = httpRequest.Headers[ApiRegistration.AppKeyHeader];

			if (string.IsNullOrEmpty(apiKey) && requestDto != null)
			{
				apiKey = requestDto.AppKey;
			}

			return apiKey;
		}
	}
}
