using Api.Contracts.Services;
using Api.Contracts.Dto;
using ServiceStack.ServiceInterface;

namespace Api.Implementations.Handlers
{
	[RequiresAppRegistration(Priority = -1, ApplyTo = ApplyTo.All)]
	public class GetSupportedServicesHandler : RestServiceBase<GetSupportedServicesRequest>
	{
		private readonly IAuthConsumerService _service;

		public GetSupportedServicesHandler(IAuthConsumerService service)
		{
			_service = service;
		}

		public override object OnGet(GetSupportedServicesRequest request)
		{
			return _service.GetSupportedServices(request);
		}
	}
}
