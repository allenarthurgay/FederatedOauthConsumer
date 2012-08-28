using Api.Contracts.Services;
using Api.Contracts.Dto;
using ServiceStack.ServiceInterface;

namespace Api.Implementations.Handlers
{
	[RequiresAppRegistration(Priority = -1, ApplyTo = ApplyTo.All)]
	public class GetServiceTokenForPrincipalIdHandler : RestServiceBase<GetServiceTokenForPrincipalIdRequest>
	{
		private readonly IAuthConsumerService _service;

		public GetServiceTokenForPrincipalIdHandler(IAuthConsumerService service)
		{
			_service = service;
		}

		public override object OnGet(GetServiceTokenForPrincipalIdRequest request)
		{
			return _service.GetServiceTokenForPrincipalId(request);
		}
	}
}
