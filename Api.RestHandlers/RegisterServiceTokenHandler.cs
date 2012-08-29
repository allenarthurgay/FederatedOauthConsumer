using Api.Contracts.Dto;
using Api.Contracts.Services;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers
{
	[RequiresAppRegistration(Priority = -1, ApplyTo = ApplyTo.All)]
	public class RegisterServiceTokenHandler : RestServiceBase<RegisterServiceTokenRequest>
	{
		private readonly IAuthConsumerService _service;

		public RegisterServiceTokenHandler(IAuthConsumerService service)
		{
			_service = service;
		}

		public override object OnPost(RegisterServiceTokenRequest request)
		{
			_service.RegisterServiceToken(request);
			return null;
		}
	}
}
