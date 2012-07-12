using System;
using System.Collections.Generic;
using System.Linq;
using Api.Contracts.Services;
using Data;

namespace Api.Implementations.Services
{
	public class ServiceProviderHtmlFactory : IServiceProviderHtmlFactory
	{    
		private readonly List<IServiceProviderHtmlService> _htmlServices;

		public ServiceProviderHtmlFactory(IEnumerable<IServiceProviderHtmlService> htmlServices)
		{
			_htmlServices = htmlServices.ToList();
		}
		
		public IServiceProviderHtmlService GetProviderHtmlService(ServiceProvider provider)
		{
			if (provider == null)
			{
				return null;
			}
			
			return
				_htmlServices.FirstOrDefault(
					c =>
					c.SupportedService.Name.ToLower() == provider.Name.ToLower());
		}

		
	}
}
