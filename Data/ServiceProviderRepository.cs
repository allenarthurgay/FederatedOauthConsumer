using System;
using ServiceStack.OrmLite;

namespace Data
{
	public class ServiceProviderRepository : DataItemRepository<ServiceProvider>
	{
        public ServiceProvider GetServiceProvider(Guid userId, string name)
        {
            using (var dbConn = DbFactory.OpenDbConnection())
            using (var dbCmd = dbConn.CreateCommand())
            {
                return dbCmd.FirstOrDefault<ServiceProvider>(record => record.UniqueId == userId
                                                                       && record.Name == name);
            }
        }
	}
}
