using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
                c.Resolve<IServiceProviderHtmlFactory>(),
                c.Resolve<IAuthTokenMassagerServiceFactory>()));

            container.Register<IEnumerable<IServiceProviderHtmlService>>(
                c => new IServiceProviderHtmlService[]
                         {
                             new FacebookServiceProviderHtmlService(),
                             new TwitterServiceProviderHtmlService(),
                         });

            container.Register<IEnumerable<IAuthProviderTokenMassager>>(
                            c => new IAuthProviderTokenMassager[]
                         {
                             new FacebookTokenMassager()                             
                         });

            container.Register<IUserTokenRepository>(
                c => new UserTokenRecordRepository(c.Resolve<IDataConnectionProvider>()));

            container.Register<IServiceProviderRepository>(
                c => new ServiceProviderRepository(c.Resolve<IDataConnectionProvider>()));

            container.Register<IServiceProviderHtmlFactory>(
                c => new ServiceProviderHtmlFactory(c.Resolve<IEnumerable<IServiceProviderHtmlService>>()));

            container.Register<IAuthTokenMassagerServiceFactory>(
                c => new AuthTokenMassagerServiceFactory(c.Resolve<IEnumerable<IAuthProviderTokenMassager>>()));
        }
    }
}
