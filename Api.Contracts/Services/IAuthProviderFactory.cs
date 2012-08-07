using Data;

namespace Api.Contracts.Services
{
	public interface IAuthProviderFactory
	{
		IAuthProviderInstance GetAuthProviderInstance(ServiceProvider provider);
	}
}
