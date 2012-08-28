using System.Collections.Generic;
using Data;

namespace Api.Contracts.Repositories
{
	public interface IAccountUserRepository : ISimpleDataItemRepository<AccountUser>
	{
		IEnumerable<AccountUser> GetForAccount(int accountId);
	}
}
