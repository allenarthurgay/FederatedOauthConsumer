using Api.Contracts.DTO;
using Api.Contracts.Services;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers.Handlers
{
	public class DeleteApplicationRequestHandler : RestServiceBase<DeleteApplicationRequest>
	{
		private readonly IApplicationBreadService _applicationBreadService;

		public DeleteApplicationRequestHandler(IApplicationBreadService applicationBreadService)
		{
			_applicationBreadService = applicationBreadService;
		}

		public override object OnDelete(DeleteApplicationRequest request)
		{
			_applicationBreadService.DeleteApplication(request);
			return null;
		}
	}
}
