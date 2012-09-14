using Api.Contracts.DTO;
using Api.Contracts.Services;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers.Handlers
{
	public class RegisterAccountRequestHandler : RestServiceBase<RegisterAccountRequest>
	{
		private readonly IAccountRegistrationService _accountRegistrationService;

		public RegisterAccountRequestHandler(IAccountRegistrationService accountRegistrationService)
		{
			_accountRegistrationService = accountRegistrationService;
		}

		public override object OnPost(RegisterAccountRequest request)
		{
			_accountRegistrationService.RegisterAccountForUser(request);
			return null;
		}
	}
}
