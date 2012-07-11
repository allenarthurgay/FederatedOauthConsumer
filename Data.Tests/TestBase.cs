using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Api.Contracts.Repositories;
using Api.Implementations.Repositories;
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

		[TestInitialize]
		public void SetUp()
		{
            ConnectionProvider = new DataConnectionProvider(DataConnectionProvider.Connectionstring);

		    UserTokenRepository = new UserTokenRecordRepository(ConnectionProvider);

		    ServiceProviderRepository =new ServiceProviderRepository(ConnectionProvider);

			new Registration().CreateTablesForTypes();
		}
	}
}
