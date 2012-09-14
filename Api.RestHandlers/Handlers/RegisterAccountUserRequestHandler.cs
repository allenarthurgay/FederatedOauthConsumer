using Api.Contracts.DTO;
using Api.Contracts.Services;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers.Handlers
{
	public class RegisterAccountUserRequestHandler : RestServiceBase<RegisterAccountUserRequest>
	{
		private readonly IUserBreadService _userBreadService;
		public RegisterAccountUserRequestHandler(IUserBreadService userBreadService)
		{
			_userBreadService = userBreadService;
		}

		public override object OnPost(RegisterAccountUserRequest request)
		{
			return _userBreadService.RegisterUserForAccount(request);
		}
	}
}
