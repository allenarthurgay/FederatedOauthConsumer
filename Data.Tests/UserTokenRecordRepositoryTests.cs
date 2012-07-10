using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests
{
	[TestClass]
	public class UserTokenRecordRepositoryTests : TestBase
	{
		[TestMethod]
		public void	Can_add_user_token_record()
		{
			var userId = Guid.NewGuid();
			var recordId = Guid.NewGuid();

			var repository = new UserTokenRecordRepository();

			var newRecord = new UserTokenRecord
			                 	{
									UniqueId = recordId,
									UserId = userId,
									ServiceType = "SomeService",
			                 		Token = "test"
			                 	};

			repository.Add(newRecord);

			var actual = repository.GetUserTokenRecord(userId, "SomeService");

			Assert.AreEqual(recordId, actual.UniqueId);
		}
	}
}
