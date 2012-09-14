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

		public IEnumerable<User> GetForAccount(int accountId)
		{
			return ConnectionProvider.ExecuteQuery(c => c.Select<User>(
				string.Format(
					"Select * from User u INNER JOIN AccountUser au ON u.Id=au.UserId where " +
					" au.AccountId={0}",
					accountId)));
		}
	}
}
