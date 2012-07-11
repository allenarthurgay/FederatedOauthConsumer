using System;
using ServiceStack.OrmLite;

namespace Data
{
	public class UserRecordRepository : DataItemRepository<UserRecord>
	{
		public UserRecord GetUserRecord(Guid userId, string serviceType)
		{
			using (var dbConn = DbFactory.OpenDbConnection())
			using (var dbCmd = dbConn.CreateCommand())
			{
				return dbCmd.FirstOrDefault<UserRecord>(record => record.UniqueId == userId
				                                                       && record.ServiceType == serviceType);
			}
		}
	}
}