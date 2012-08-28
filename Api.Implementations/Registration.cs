using System.Collections.Generic;
using Api.Contracts.Repositories;
using Api.Contracts.Services;
using Api.Implementations.Repositories;
using Api.Implementations.Services;
using Core;
using Funq;

namespace Api.Implementations
{
	public class Registration : IFunqRegistrationModule
	{
		public void RegisterDependencies(Container container)
		{
			container.Register<IAuthConsumerService>(c => new AuthConsumerService(c.Resolve<IUserTokenRepository>(),
				c.Resolve<IServiceProviderRepository>(),
				c.Resolve<IAuthProviderFactory>()));

			container.Register<IApplicationAuthenticationService>(
				c => new ApplicationAuthenticationService(c.Resolve<IApplicationRepository>()));

			container.Register<IEnumerable<IAuthProviderInstance>>(
				c => new IAuthProviderInstance[]
							{
								new FacebookAuthProviderInstance(),
								new YammerAuthProviderInstance()
							});

			RegisterRepositories(container);
		}

		private static void RegisterRepositories(Container container)
		{
			container.Register<IUserTokenRepository>(
				c => new UserTokenRecordRepository(c.Resolve<IDataConnectionProvider>()));

			container.Register<IServiceProviderRepository>(
				c => new ServiceProviderRepository(c.Resolve<IDataConnectionProvider>()));

			container.Register<IAuthProviderFactory>(
				c => new AuthProviderFactory(c.Resolve<IEnumerable<IAuthProviderInstance>>()));

			container.Register<IApplicationRepository>(
				c => new ApplicationRepository(c.Resolve<IDataConnectionProvider>()));

			container.Register<IApplicationServiceRepository>(
				c => new ApplicationServiceRepository(c.Resolve<IDataConnectionProvider>()));

			container.Register<IAccountApplicationRepository>(
				c => new AccountApplicationRepository(c.Resolve<IDataConnectionProvider>()));

			container.Register<IAccountRepository>(
				c => new AccountRepository(c.Resolve<IDataConnectionProvider>()));

			container.Register<IAccountUserRepository>(
				c => new AccountUserRepository(c.Resolve<IDataConnectionProvider>()));

			container.Register<IUserRepository>(
				c => new UserRepository(c.Resolve<IDataConnectionProvider>()));
		}
	}
}
