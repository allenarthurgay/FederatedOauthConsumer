using System;
using System.IO;
using System.Net;
using Api.RestServiceHost.App_Start;
using Api.RestServiceHost.Contracts;
using ServiceStack.ServiceInterface;

namespace Api.RestServiceHost.Handlers
{
	public class GetGroupsHandler : RestServiceBase<GetGroupsRequest>
	{
		private static readonly string UserToken = "yRVmP0k8B2qWP6oLTjw";

		public override object OnGet(GetGroupsRequest request)
		{
			var webRequest = CreateRequest("https://www.yammer.com/api/v1/groups/");

			try
			{
				using (var reader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
				{
					return reader.ReadToEnd();
				}
			}
			catch (Exception e)
			{
				return e;
			}

		}

		private HttpWebRequest CreateRequest(string url)
		{
			var webRequest = (HttpWebRequest)WebRequest.Create(url);

			//webRequest.Headers.Add(HttpRequestHeader.Authorization, CreateAuthorizationHeader());
			//webRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer BecS4c1AF3nDwsGujAJP7Q");
			webRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + UserToken);

			return webRequest;
		}

	}
}