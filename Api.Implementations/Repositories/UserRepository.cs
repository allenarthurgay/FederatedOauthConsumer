using System;
using System.Linq;
using Api.Contracts.Repositories;
using Core;
using Data;
using ServiceStack.OrmLite;

namespace Api.Implementations.Repositories
{
	public class UserRepository : BaseDataItemRepository<User>, IUserRepository
	{
		public UserRepository(IDataConnectionProvider connectionProvider) : base(connectionProvider)
		{
		}

		public User Find(string email, string password)
		{
			return ConnectionProvider.ExecuteQuery(c =>
				c.Where<User>(new { Email = email, Password = password }).FirstOrDefault());
		}

		public void UpdateLastLoginDate(int userId)
		{
			ConnectionProvider.WithCommand(cmd=>
			                               	{
												var user = cmd.Select<User>(c => c.Id == userId).FirstOrDefault();
												if (user != null)
												{
													user.LastLogin = DateTime.UtcNow;
													cmd.Update(user);
												}
			                               	});
		}
	}
}
