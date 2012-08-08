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
	public class CreatePostHandler : RestServiceBase<CreatePostRequest>
	{
		private static readonly string UserToken = "yRVmP0k8B2qWP6oLTjw";

		public override object OnPost(CreatePostRequest request)
		{
			var webRequest = CreateRequest("https://www.yammer.com/api/v1/messages?group_id=" 
				+ GroupMap.GetGroupId(request.ProjectId) 
				+ "&body=" 
				+ HttpUtility.UrlEncode(request.Message));
			webRequest.Method = "POST";

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

			webRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + UserToken);

			return webRequest;
		}
	}
}