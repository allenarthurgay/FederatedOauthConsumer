using System;
using ServiceStack.OrmLite;

namespace Data
{
	public class UserTokenRecordRepository : DataItemRepository<UserTokenRecord>
	{
		public UserTokenRecord GetUserTokenRecord(Guid userId, string serviceType)
		{
			using (var dbConn = DbFactory.OpenDbConnection())
			using (var dbCmd = dbConn.CreateCommand())
			{
				return dbCmd.FirstOrDefault<UserTokenRecord>(record => record.UserId == userId
				                                                       && record.ServiceType == serviceType);
			}
		}
	}
}