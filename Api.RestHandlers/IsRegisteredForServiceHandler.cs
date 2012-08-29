using Api.Contracts.Dto;
using Api.Contracts.Services;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers
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
