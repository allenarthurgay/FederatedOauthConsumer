using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
			var userId = Guid.NewGuid();
			var recordId = Guid.NewGuid();			

			var newRecord = new UserTokenRecord
			                 	{
									UniqueId = recordId,
									UserId = userId,
									ServiceType = "SomeService",
			                 		Token = "test"
			                 	};

			UserTokenRepository.Add(newRecord);

            var actual = UserTokenRepository.GetUserTokenRecord(userId, "SomeService");

			Assert.AreEqual(recordId, actual.UniqueId);
		}
	}
}
