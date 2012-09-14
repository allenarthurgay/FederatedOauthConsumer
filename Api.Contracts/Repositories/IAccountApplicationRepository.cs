using System.Collections.Generic;
using Data;

namespace Api.Contracts.Repositories
{
	public interface IAccountApplicationRepository : ISimpleDataItemRepository<AccountApplication>
	{
		IEnumerable<AccountApplication> GetForAccount(int accountId);

		Account GetForApplication(int applicationId);
	}
}
