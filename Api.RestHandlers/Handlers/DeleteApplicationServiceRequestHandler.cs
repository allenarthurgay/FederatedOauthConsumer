using Api.Contracts.DTO;
using Api.Contracts.Services;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers.Handlers
{
	public class DeleteApplicationServiceRequestHandler : RestServiceBase<DeleteApplicationServiceRequest>
	{
		private readonly IApplicationBreadService _applicationBreadService;

		public DeleteApplicationServiceRequestHandler(IApplicationBreadService applicationBreadService)
		{
			_applicationBreadService = applicationBreadService;
		}
		public override object OnDelete(DeleteApplicationServiceRequest request)
		{
			_applicationBreadService.DeleteApplicationService(request);
			return null;
		}
	}
}
