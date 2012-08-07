using System;
using System.Linq;
using Api.Contracts.Repositories;
using Api.Contracts.dto;
using Api.Implementations.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests
{
	[TestClass]
	public class ServiceProviderRepositoryTests : TestBase
	{
		[TestMethod]
		public void Can_get_all_service_types()
		{
		    AuthConsumerService.RegisterServiceProvider(new RegisterServiceProviderRequest {Name = "facebook"});
            AuthConsumerService.RegisterServiceProvider(new RegisterServiceProviderRequest { Name = "yammer" });
		}
	}
}
