using System.Linq;
using Api.Contracts.DTO;
using Api.Contracts.Repositories;
using Api.Contracts.Services;
using Data;

namespace Api.Implementations.Services
{
	public class UserBreadService : IUserBreadService
	{
		private readonly IAccountUserRepository _accountUserRepository;
		private readonly IUserRepository _userRepository;


		public UserBreadService(IAccountUserRepository accountUserRepository,
			IUserRepository userRepository)
		{
			_accountUserRepository = accountUserRepository;
			_userRepository = userRepository;
		}

		public EnumerableResponse<User> BrowseUsersForAccount(BrowseAccountUsersRequest request)
		{
			return new EnumerableResponse<User>
				{
					Items = _accountUserRepository.GetForAccount(request.Account.Id).ToList()
				};			
		}

		public User RegisterUserForAccount(RegisterAccountUserRequest request)
		{
			_accountUserRepository.Add(new AccountUser
				{
					UserId = request.User.Id,
					AccountId = request.Account.Id
				});
			return request.User;
		}

		public User GetUser(GetUserRequest request)
		{
			return _userRepository.GetById(request.Id);
		}
	}
}
