using Api.Contracts.Services;
using Api.Contracts.Dto;
using ServiceStack.ServiceInterface;

namespace Api.Implementations.Handlers
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
