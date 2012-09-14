using Api.Contracts.DTO;
using Api.Contracts.Services;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers.Handlers
{
	[RequiresAppRegistration(Priority = -1, ApplyTo = ApplyTo.All)]
	public class AddApplicationServiceRequestHandler : RestServiceBase<AddApplicationServiceRequest>
	{
		private readonly IApplicationBreadService _applicationBreadService;

		public AddApplicationServiceRequestHandler(IApplicationBreadService applicationBreadService)
		{
			_applicationBreadService = applicationBreadService;
		}

		public override object OnPut(AddApplicationServiceRequest request)
		{
			return _applicationBreadService.RegisterServiceForApplication(request);		
		}
	}
}
