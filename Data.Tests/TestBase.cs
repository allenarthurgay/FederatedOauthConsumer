using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Api.Contracts.Repositories;
using Api.Contracts.Services;
using Api.Implementations.Repositories;
using Api.Implementations.Services;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests
{
	[TestClass]
	public abstract class TestBase
	{
        public IDataConnectionProvider ConnectionProvider { get; set; }

        public IUserTokenRepository UserTokenRepository { get; set; }

        public IServiceProviderRepository ServiceProviderRepository { get; set; }

        public IAuthConsumerService AuthConsumerService { get; set; }

        public IAuthProviderFactory AuthProviderFactory { get; set; }
		[TestInitialize]
		public void SetUp()
		{
            ConnectionProvider = new DataConnectionProvider(DataConnectionProvider.Connectionstring);

		    UserTokenRepository = new UserTokenRecordRepository(ConnectionProvider);

		    ServiceProviderRepository =new ServiceProviderRepository(ConnectionProvider);

            AuthProviderFactory = new AuthProviderFactory(new[]
                {
                    new FacebookAuthProviderInstance()
                });
            AuthConsumerService = new AuthConsumerService(UserTokenRepository,
                ServiceProviderRepository, AuthProviderFactory);

			new Registration().CreateTablesForTypes();
		}
	}
}
