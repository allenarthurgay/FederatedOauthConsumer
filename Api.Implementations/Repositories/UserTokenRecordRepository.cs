using System;
using Api.Contracts.Repositories;
using Core;
using Data;
using ServiceStack.OrmLite;

namespace Api.Implementations.Repositories
{
    public class UserTokenRecordRepository : BaseDataItemRepository<UserTokenRecord>, IUserTokenRepository
	{
        public UserTokenRecordRepository(IDataConnectionProvider connectionProvider) : base(connectionProvider)
        {
        }

        public UserTokenRecord GetUserTokenRecord(Guid userId, string serviceType)
        {
        	try
        	{
				return ConnectionProvider.ExecuteQuery(cmd =>
													   ReadExtensions.FirstOrDefault<UserTokenRecord>(cmd, record => record.UserId == userId &&
																									 record.ServiceType == serviceType));
        	}
        	catch (Exception)
        	{

        		return null;
        	}

        }
	}
}