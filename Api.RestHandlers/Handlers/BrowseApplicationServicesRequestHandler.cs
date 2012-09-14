using Api.Contracts.DTO;
using Api.Contracts.Services;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers.Handlers
{
	public class BrowseApplicationServicesRequestHandler : RestServiceBase<BrowseApplicationServicesRequest>
	{
		private readonly IApplicationBreadService _applicationBreadService;

		public BrowseApplicationServicesRequestHandler(IApplicationBreadService applicationBreadService)
		{
			_applicationBreadService = applicationBreadService;
		}

		public override object OnGet(BrowseApplicationServicesRequest request)
		{
			return _applicationBreadService.BrowseServicesForApplication(request);
		}
	}
}
