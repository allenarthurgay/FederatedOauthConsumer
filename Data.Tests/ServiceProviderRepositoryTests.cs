using System;
using System.Linq;
using Api.Contracts.Repositories;
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
			var recordId = Guid.NewGuid();			

			var newRecord1 = new ServiceProvider()
			{
				UniqueId = recordId,
				Name = Guid.NewGuid().ToString()
			};

			var newRecord2 = new ServiceProvider()
			{
				UniqueId = recordId,
				Name = Guid.NewGuid().ToString()
			};
												
			ServiceProviderRepository.Add(newRecord1);
			ServiceProviderRepository.Add(newRecord2);

			var serviceList = ServiceProviderRepository.GetAll().ToList();

			Assert.IsNotNull(serviceList.FirstOrDefault(s => s.Name == newRecord1.Name));
			Assert.IsNotNull(serviceList.FirstOrDefault(s => s.Name == newRecord2.Name));
		}
	}
}
