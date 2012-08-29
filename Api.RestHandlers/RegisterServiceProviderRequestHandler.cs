using Api.Contracts.Dto;
using Api.Contracts.Services;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers
{
	[RequiresAppRegistration(Priority = -1, ApplyTo = ApplyTo.All)]
	public class RegisterServiceProviderRequestHandler: RestServiceBase<RegisterServiceProviderRequest>
	{		
		private readonly IAuthConsumerService _service;

		public RegisterServiceProviderRequestHandler(IAuthConsumerService service)
		{
			_service = service;
		}

		public override object OnPost(RegisterServiceProviderRequest request)
		{
			_service.RegisterServiceProvider(request);
			return null;
		}
	}
}
