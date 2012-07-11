using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace Data.Tests
{
	[TestClass]
	public class UserTokenRecordRepositoryTests : TestBase
	{
                public void Setup()
        {
            
        }

		[TestMethod]
		public void	Can_add_user_token_record()
		{
			var recordId = Guid.NewGuid();

			var repository = new UserRecordRepository();

			var newRecord = new UserRecord
			                 	{
									UniqueId = recordId,
									ServiceType = "SomeService",
			                 	};

			repository.Add(newRecord);

			var actual = repository.GetUserRecord(recordId, "SomeService");

			Assert.AreEqual(recordId, actual.UniqueId);
		}

        public void Can_add_service_provider_record()
        {
            var recordId = Guid.NewGuid();

            var repository = new ServiceProviderRepository();

            var newRecord = new ServiceProvider
                                {
                                    UniqueId = recordId,
                                    Name = "SomeName"
                                };

            repository.Add(newRecord);

            var actual = repository.GetServiceProvider(recordId, "SomeName");

            Assert.AreEqual(recordId, actual.UniqueId);
        }
	}
}
