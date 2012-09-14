using Api.Contracts.DTO;
using Api.Contracts.Services;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers.Handlers
{
	public class GetUserRequestHandler : RestServiceBase<GetUserRequest>
	{
		private readonly IUserBreadService _userBreadService;

		public GetUserRequestHandler(IUserBreadService userBreadService)
		{
			_userBreadService = userBreadService;
		}

		public override object OnGet(GetUserRequest request)
		{
			return _userBreadService.GetUser(request);
		}
	}
}
