using Data;

namespace Api.Contracts.Repositories
{
	public interface IUserRepository: ISimpleDataItemRepository<User>
	{
		User Find(string email, string password);

		void UpdateLastLoginDate(int userId);
	}
}
