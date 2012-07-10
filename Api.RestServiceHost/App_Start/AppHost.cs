using Api.Contracts;
using Api.Contracts.dto;
using Api.Implementations.Handlers;
using Core;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.ServiceInterface.Admin;
using ServiceStack.ServiceInterface.Validation;
using ServiceStack.WebHost.Endpoints;

namespace Api.RestServiceHost.App_Start
{
	public class AppHost
		: AppHostBase
	{		
		public AppHost() //Tell ServiceStack the name and where to find your web services
            : base("StarterTemplate ASP.NET Host", typeof(EmptyExampleHandler).Assembly) { }

		public override void Configure(Funq.Container container)
		{
			//Set JSON web services to return idiomatic JSON camelCase properties
			ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

		    Routes.Add<EmptyDto>("/empty");
			Routes.Add<GetSupportedServicesRequest>("/supportedservices");
			Routes.Add<IsRegisteredForServiceRequest>("/id/{PrincipalId}/service/{Service}/registeredforservice");
			Routes.Add<GetRegistrationHtmlRequest>("/id/{PrincipalId}/service/{Service}/registrationhtml");
			Routes.Add<GetServiceTokenForPrincipalIdRequest>("/id/{PrincipalId}/service/{Service}/gettoken");

			//Change the default ServiceStack configuration
			SetConfig(new EndpointHostConfig {
			    DebugMode = true, //Show StackTraces in responses in development
			});

            Plugins.Add(new ValidationFeature());

            Plugins.Add(new RequestLogsFeature());
			
			//Register In-Memory Cache provider. 
			//For Distributed Cache Providers Use: PooledRedisClientManager, BasicRedisClientManager or see: https://github.com/ServiceStack/ServiceStack/wiki/Caching
			container.Register<ICacheClient>(new MemoryCacheClient());


			//Set MVC to use the same Funq IOC as ServiceStack
			ServiceRegistration.RegisterAllContainers(container);
		}


	}
}