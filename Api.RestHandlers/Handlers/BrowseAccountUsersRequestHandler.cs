using Api.Contracts.DTO;
using Api.Contracts.Services;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers.Handlers
{
	public class BrowseAccountUsersRequestHandler : RestServiceBase<BrowseAccountUsersRequest>
	{
		private readonly IUserBreadService _userBreadService;

		public BrowseAccountUsersRequestHandler(IUserBreadService userBreadService)
		{
			_userBreadService = userBreadService;
		}

		public override object OnGet(BrowseAccountUsersRequest request)
		{
			return _userBreadService.BrowseUsersForAccount(request);
		}
	}
}
