using System;
using System.Collections.Generic;
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
	        var provider= ConnectionProvider.ExecuteQuery(cmd => cmd
	                                                          .Select<ServiceProvider>(
	                                                              s =>
	                                                              s.Name.ToLower() ==service.ToLower()).FirstOrDefault());
            if(provider == null)
            {
                throw new InvalidOperationException("Can't get service by name: " + service);
            }
	        return provider;
	    }

		public List<string> GetSupportedServices()
		{
			var servicePrividers = ConnectionProvider.ExecuteQuery(cmd => cmd.Select<ServiceProvider>());
			return servicePrividers.Select(svc => svc.Name).ToList();
		}

	    public ServiceProvider AddServiceProvider(string name)
	    {
	        ConnectionProvider.TransactionWithCommand(cmd=>
	            {
	                var provider =
	                    cmd.Select<ServiceProvider>(
	                        c => c.Name==name)
                            .FirstOrDefault();

                    if(provider == null)
                    {
                        cmd.Insert(new ServiceProvider
                            {
                                Name = name
                            });
                    }
	            });
	        return GetByServiceName(name);
	    }
	}
}
