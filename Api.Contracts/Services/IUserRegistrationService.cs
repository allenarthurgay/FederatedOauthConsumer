using Api.Contracts.DTO;
using Data;

namespace Api.Contracts.Services
{
	public interface IAccountRegistrationService
	{
		void RegisterAccountForUser(RegisterAccountRequest request);

		void RegisterAuthServiceForAccount(RegisterAuthServiceProvider request);		
	}

	public class RegisterAuthServiceProvider
	{
	}

	public class RegisterAccount
	{
	}

	public class RegisterUserRequest
	{
		
	}
}
