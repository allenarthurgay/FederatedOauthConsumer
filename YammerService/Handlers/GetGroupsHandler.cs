using Api.RestServiceHost.App_Start;
using Api.RestServiceHost.Contracts;
using ServiceStack.ServiceInterface;

namespace Api.RestServiceHost.Handlers
{
	public class GetGroupsHandler : RestServiceBase<GetGroupsRequest>
	{

		public override object OnGet(GetGroupsRequest request)
		{
			return null;
		}

	}
}