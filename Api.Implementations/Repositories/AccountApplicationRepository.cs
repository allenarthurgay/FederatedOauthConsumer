using System.Collections.Generic;
using System.Linq;
using Api.Contracts.Repositories;
using Core;
using Data;
using ServiceStack.OrmLite;

namespace Api.Implementations.Repositories
{
	public class AccountApplicationRepository : BaseDataItemRepository<AccountApplication>, IAccountApplicationRepository
	{
		public AccountApplicationRepository(IDataConnectionProvider connectionProvider)
			: base(connectionProvider)
		{
		}

		public IEnumerable<AccountApplication> GetForAccount(int accountId)
		{
			return ConnectionProvider.ExecuteQuery(c =>
														c.Where<AccountApplication>(new
																						{
																							AccountId = accountId
																						}));
		}
	}
}
