using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests
{
	[TestClass]
	public class UserTokenRecordRepositoryTests
	{
		[TestMethod]
		public void Can_add_user_token_record()
		{
			new Registration().CreateTablesForTypes();

			var userId = Guid.NewGuid();
			var recordId = Guid.NewGuid();

			var reporitosty = new UserTokenRecordRepository();

			var newRecord = new UserTokenRecord
			                 	{
									UniqueId = recordId,
									UserId = userId,
									ServiceType = "SomeService",
			                 		Token = "test"
			                 	};

			reporitosty.Add(newRecord);

			var actual = reporitosty.GetUserTokenRecord(userId, "SomeService");

			Assert.AreEqual(recordId, actual.UniqueId);
		}
	}
}
