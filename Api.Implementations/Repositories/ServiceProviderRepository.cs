using System;
using System.Linq;
using Api.Contracts.Repositories;
using Core;
using Data;
using ServiceStack.OrmLite;

namespace Api.Implementations.Repositories
{
	public class ServiceProviderRepository : BaseDataItemRepository<ServiceProvider>, IServiceProviderRepository
	{
	    public ServiceProviderRepository(IDataConnectionProvider connectionProvider) : base(connectionProvider)
	    {
	    }

	    public ServiceProvider GetByServiceName(string service)
	    {
	        return ConnectionProvider.ExecuteQuery(cmd => cmd
	                                                          .Select<ServiceProvider>(
	                                                              s =>
	                                                              s.Name.ToLower() ==service.ToLower()).FirstOrDefault());
	    }
	}
}
