using Api.Contracts.DTO;
using Api.Contracts.Services;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers.Handlers
{
	public class AddApplicationRequestHandler : RestServiceBase<AddApplicationRequest>
	{
		private readonly IApplicationBreadService _applicationBreadService;

		public AddApplicationRequestHandler(IApplicationBreadService applicationBreadService)
		{
			_applicationBreadService = applicationBreadService;
		}

		public override object OnPut(AddApplicationRequest request)
		{
			return _applicationBreadService.RegisterApplicationForAccount(request);			
		}
	}
}
