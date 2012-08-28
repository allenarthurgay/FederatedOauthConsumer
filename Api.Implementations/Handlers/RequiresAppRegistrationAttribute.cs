using System;
using System.Net;
using Api.Contracts.Services;
using Api.Contracts.Dto;
using ServiceStack.Logging;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace Api.Implementations.Handlers
{
	[AttributeUsage(AttributeTargets.Class)]
	public class RequiresAppRegistrationAttribute: RequestFilterAttribute
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(RequiresAppRegistrationAttribute));

		public IApplicationAuthenticationService ApplicationAuthenticationService { get; set; }

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
			}
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
