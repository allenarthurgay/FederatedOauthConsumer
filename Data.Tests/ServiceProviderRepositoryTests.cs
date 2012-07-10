using System;
using System.Linq;
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

			var repository = new ServiceProviderRepository();


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
												
			repository.Add(newRecord1);
			repository.Add(newRecord2);

			var serviceList = repository.GetAll().ToList();

			Assert.IsNotNull(serviceList.FirstOrDefault(s => s.Name == newRecord1.Name));
			Assert.IsNotNull(serviceList.FirstOrDefault(s => s.Name == newRecord2.Name));
		}
	}
}
