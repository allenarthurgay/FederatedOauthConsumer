using System.Collections.Generic;
using Api.Contracts.Repositories;
using Core;
using Data;
using ServiceStack.OrmLite;

namespace Api.Implementations.Repositories
{
	public class AccountUserRepository :  BaseDataItemRepository<AccountUser>, IAccountUserRepository
	{
		public AccountUserRepository(IDataConnectionProvider connectionProvider) : base(connectionProvider)
		{
		}

		public IEnumerable<AccountUser> GetForAccount(int accountId)
		{
			return ConnectionProvider.ExecuteQuery(c =>
														c.Where<AccountUser>(new
														{
															AccountId = accountId
														}));
		}
	}
}
