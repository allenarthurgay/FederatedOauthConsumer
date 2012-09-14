using Api.Contracts.DTO;
using Data;

namespace Api.Contracts.Services
{
	public interface IUserBreadService
	{
		EnumerableResponse<User> BrowseUsersForAccount(BrowseAccountUsersRequest request);

		User RegisterUserForAccount(RegisterAccountUserRequest request);

		User GetUser(GetUserRequest request);
	}
}
