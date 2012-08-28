using Data;

namespace Api.Contracts.Services
{
	public interface IAccountRegistrationService
	{
		void RegisterUser(RegisterUser request);

		void RegisterAccountForUser(RegisterAccount request);

		void RegisterAuthServiceForAccount(RegisterAuthServiceProvider request);
		
	}

	public class RegisterAuthServiceProvider
	{
	}

	public class RegisterAccount
	{
	}

	public class RegisterUser
	{
		
	}
}
