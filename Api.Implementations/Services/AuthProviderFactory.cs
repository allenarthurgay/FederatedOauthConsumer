using System.Collections.Generic;
using System.Linq;
using Api.Contracts.Services;
using Data;

namespace Api.Implementations.Services
{
	public class AuthProviderFactory: IAuthProviderFactory
	{
		private readonly List<IAuthProviderInstance> _authProviderInstances;

		public AuthProviderFactory(IEnumerable<IAuthProviderInstance> authProviderInstances)
		{
			_authProviderInstances = authProviderInstances.ToList();
		}

		public IAuthProviderInstance GetAuthProviderInstance(ServiceProvider provider)
		{
			return
				_authProviderInstances.FirstOrDefault(
					c =>
					c.SupportedService.Name.ToLower() == provider.Name.ToLower());
		}
	}
}
