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

		public UserTokenRecord GetUserTokenRecord(Guid userId, int serviceId)
		{
			try
			{
				return ConnectionProvider.ExecuteQuery(cmd =>
													   cmd.FirstOrDefault<UserTokenRecord>(record => record.UserId == userId &&
													                      record.ServiceTypeId == serviceId));
			}
			catch (Exception)
			{

				return null;
			}

		}
	}
}