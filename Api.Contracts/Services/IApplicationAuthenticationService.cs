using Data;

namespace Api.Contracts.Services
{
	public interface IApplicationAuthenticationService
	{
		Application Authenticate(string appKey, string appSecret);
	}
}
