using Api.Contracts.Services;
using Api.Contracts.Dto;
using ServiceStack.ServiceInterface;

namespace Api.Implementations.Handlers
{
	[RequiresAppRegistration(Priority = -1, ApplyTo = ApplyTo.All)]
	public class IsRegisteredForServiceHandler : RestServiceBase<IsRegisteredForServiceRequest>
	{
		private readonly IAuthConsumerService _service;

		public IsRegisteredForServiceHandler(IAuthConsumerService service)
		{
			_service = service;
		}

		public override object OnGet(IsRegisteredForServiceRequest request)
		{
			return _service.IsRegisteredForService(request);
		}
	}
}
