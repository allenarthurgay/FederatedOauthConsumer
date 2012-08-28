using Api.Contracts.Repositories;
using Core;
using Data;

namespace Api.Implementations.Repositories
{
	public class AccountRepository : BaseDataItemRepository<Account>, IAccountRepository
	{
		public AccountRepository(IDataConnectionProvider connectionProvider) : base(connectionProvider)
		{
		}
	}
}
