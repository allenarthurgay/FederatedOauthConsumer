using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Api.Contracts.DTO;
using Api.Contracts.Repositories;
using Api.Contracts.Services;
using Api.Implementations.Repositories;
using Api.Implementations.Services;
using Core;
using Data;
using Funq;

namespace Api.Implementations
{
	public class Registration : IFunqRegistrationModule
	{
		public IHandlerMapper Mapper;


		public void RegisterDependencies(Container container)
		{
			container.Register<IAuthConsumerService>(c => new AuthConsumerService(c.Resolve<IUserTokenRepository>(),
				c.Resolve<IServiceProviderRepository>(),
				c.Resolve<IAuthProviderFactory>()));

			container.Register<IUserBreadService>(
				c => new UserBreadService(c.Resolve<IAccountUserRepository>(), c.Resolve<IUserRepository>()));


			container.Register<IApplicationAuthenticationService>(
				c => new ApplicationAuthenticationService(c.Resolve<IApplicationRepository>()));

			container.Register<IEnumerable<IAuthProviderInstance>>(
				c => new IAuthProviderInstance[]
							{
								new FacebookAuthProviderInstance(),
								new YammerAuthProviderInstance()
							});

			RegisterRepositories(container);


		//	Mapper.Register<RegisterAccountUserRequest, User>(UserBreadService.RegisterUserForAccount);

		}

		private void MapDtos(Container container)
		{
			var instance = container.Resolve<IUserBreadService>();

			var methods = instance.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);

			var methodsWithOneParam = methods.Where(m => m.GetParameters().Length > 0);

			foreach (var methodInfo in methodsWithOneParam)
			{
				var paraminfos =
					methodInfo.GetParameters();

				var paramType = paraminfos[0].GetType();
				var m = methodInfo;					
				Mapper.Register(paramType, (t)=> m.Invoke(instance, new[] {t}));
			}
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
