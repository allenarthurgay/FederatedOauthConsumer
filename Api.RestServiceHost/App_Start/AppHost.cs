using System;
using System.Collections.Generic;
using Api.Contracts;
using Api.Contracts.dto;
using Api.Implementations.Handlers;
using Api.RazorViews;
using Core;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Razor;
using ServiceStack.ServiceInterface.Admin;
using ServiceStack.ServiceInterface.Validation;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.WebHost.Endpoints.Formats;

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

			Routes.Add<EmptyDto>("/empty")
				.Add<GetSupportedServicesRequest>("/supportedservices")
				.Add<GetRegistrationHtmlRequest>("/{Service}/registrationhtml")
				.Add<IsRegisteredForServiceRequest>("/{PrincipalId}/{Service}/isregistered")
				.Add<GetServiceTokenForPrincipalIdRequest>("/{PrincipalId}/{Service}/gettoken")
				.Add<RegisterServiceTokenRequest>("/register");

			//Change the default ServiceStack configuration
			SetConfig(new EndpointHostConfig
			{
				DebugMode = true, //Show StackTraces in responses in development

				//enable CORS
				GlobalResponseHeaders = {	{ "Access-Control-Allow-Origin", "*" }, 
											{ "Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS" },
											{ "Access-Control-Allow-Headers", "Content-Type" },
										}

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