using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Api.RestServiceHost.Contracts;
using ServiceStack.ServiceInterface;

namespace Api.RestServiceHost.Handlers
{
	public class CreateGroupHandler : RestServiceBase<CreateGroupRequest>
	{
		private static readonly string UserToken = "yRVmP0k8B2qWP6oLTjw";

		public override object OnPost(CreateGroupRequest request)
		{
			if (!string.IsNullOrEmpty(GroupMap.GetGroupId(request.ProjectId)))
			{
				throw new Exception("Group already exists for project id " + request.ProjectId);
			}
			var webRequest = CreateRequest("https://www.yammer.com/api/v1/groups/?private=true&name=" + HttpUtility.UrlEncode(request.Name));

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
			webRequest.Method = "POST";

			return webRequest;
		}
	}
}