using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

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

			var repository = new UserRecordRepository();

			var newRecord = new UserRecord
			                 	{
									UniqueId = recordId,
									//UserId = userId,
									ServiceType = "SomeService",
			                 	};

			repository.Add(newRecord);

			var actual = repository.GetUserRecord(userId, "SomeService");

			Assert.AreEqual(recordId, actual.UniqueId);
		}
	}
}
