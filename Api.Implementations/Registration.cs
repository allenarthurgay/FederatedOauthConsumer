using System.Collections.Generic;
using Api.Contracts.Repositories;
using Api.Contracts.Services;
using Api.Implementations.Repositories;
using Api.Implementations.Services;
using Core;

namespace Api.Implementations
{
	public class Registration : IFunqRegistrationModule
	{
		public void RegisterDependencies(Funq.Container container)
		{
			container.Register<IAuthConsumerService>(c => new AuthConsumerService(c.Resolve<IUserTokenRepository>(),
				c.Resolve<IServiceProviderRepository>(),
				c.Resolve<IAuthProviderFactory>()));

			container.Register<IEnumerable<IAuthProviderInstance>>(
				c => new IAuthProviderInstance[]
							{
								new FacebookAuthProviderInstance(),
                                new YammerAuthProviderInstance()
							});

			container.Register<IUserTokenRepository>(
				c => new UserTokenRecordRepository(c.Resolve<IDataConnectionProvider>()));

			container.Register<IServiceProviderRepository>(
				c => new ServiceProviderRepository(c.Resolve<IDataConnectionProvider>()));

			container.Register<IAuthProviderFactory>(
				c => new AuthProviderFactory(c.Resolve<IEnumerable<IAuthProviderInstance>>()));

		}
	}
}
