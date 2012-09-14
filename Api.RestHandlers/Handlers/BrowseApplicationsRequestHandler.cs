using Api.Contracts.DTO;
using Api.Contracts.Services;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers.Handlers
{
	public class BrowseApplicationsRequestHandler : RestServiceBase<BrowseApplicationsRequest>
	{
		private readonly IApplicationBreadService _applicationBreadService;

		public BrowseApplicationsRequestHandler(IApplicationBreadService applicationBreadService)
		{
			_applicationBreadService = applicationBreadService;
		}

		public override object OnGet(BrowseApplicationsRequest request)
		{
			return _applicationBreadService.BrowseApplications(request);
		}
	}
}
