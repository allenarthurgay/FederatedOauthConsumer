using Api.RestServiceHost.Contracts;
using Api.RestServiceHost.Handlers;
using Core;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.ServiceInterface.Admin;
using ServiceStack.ServiceInterface.Validation;
using ServiceStack.WebHost.Endpoints;

namespace Api.RestServiceHost.App_Start
{
	static class Paths
	{
		private static string baseUrl = "";
		public static string GetAllPosts = "???";
		public static string GetPostsInGroup = "project/{ProjectId}/allposts";
		public static string PostInGroup = "project/{ProjectId}/newpost";
		public static string GetGroups = "projects/";
		public static string CreateGroup = "project/{ProjectId}/create";
	}

	public class AppHost
		: AppHostBase
	{
		public AppHost() //Tell ServiceStack the name and where to find your web services
			: base("StarterTemplate ASP.NET Host", typeof(EmptyExampleHandler).Assembly) { }

		public override void Configure(Funq.Container container)
		{
			//Set JSON web services to return idiomatic JSON camelCase properties
			ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

			Routes
				//.Add<EmptyDto>("/empty")
				.Add<GetPostsRequest>(Paths.GetPostsInGroup)
				.Add<CreatePostRequest>(Paths.PostInGroup)
				.Add<GetGroupsRequest>(Paths.GetGroups)
				.Add<CreateGroupRequest>(Paths.CreateGroup)
				;
				

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