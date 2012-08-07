using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Api.Contracts.Services
{
	public interface IAuthProviderInstance
	{
		ServiceProvider SupportedService { get; }

		/// <summary>
		///this allows a 3rd parth auth provider the opportunity to take the "Token" string, parse it into a DTO,
		///and then serialize it into a normalized string
		/// </summary>
		/// <param name="serviceAuthToken"></param>
		/// <returns></returns>
		string NormalizeToken(string serviceAuthToken);

		string GetHtmlForService(ServiceProvider provider);
	}
}
