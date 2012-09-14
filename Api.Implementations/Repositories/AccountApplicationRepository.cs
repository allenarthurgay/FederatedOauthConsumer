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

		public Account GetForApplication(int applicationId)
		{
			return ConnectionProvider.ExecuteQuery(c =>
				{
					var accountApplication = c.Where<AccountApplication>(new
						{
							ApplicationId = applicationId
						}).FirstOrDefault();

					return c.Where<Account>(new {Id = accountApplication.AccountId}).FirstOrDefault();
				});

		}
	}
}
