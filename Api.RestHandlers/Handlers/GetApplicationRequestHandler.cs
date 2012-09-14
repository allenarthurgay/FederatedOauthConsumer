using Api.Contracts.DTO;
using Api.Contracts.Services;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers.Handlers
{
	public class GetApplicationRequestHandler : RestServiceBase<GetApplicationRequest>
	{
		private readonly IApplicationBreadService _applicationBreadService;

		public GetApplicationRequestHandler(IApplicationBreadService applicationBreadService)
		{
			_applicationBreadService = applicationBreadService;
		}

		public override object OnGet(GetApplicationRequest request)
		{
			return _applicationBreadService.GetApplication(request);
		}
	}
}
