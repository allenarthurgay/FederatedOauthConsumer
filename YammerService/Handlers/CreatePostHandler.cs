using System;
using System.IO;
using System.Net;
using System.Web;
using Api.RestServiceHost.Contracts;
using Api.RestServiceHost.Services;
using ServiceStack.Common.Web;
using ServiceStack.ServiceInterface;

namespace Api.RestServiceHost.Handlers
{
	public class CreatePostHandler : RestServiceBase<CreatePostRequest>
	{
        private readonly IAuthenticatedYammerRequestFactory _authenticatedYammerRequestFactory;
	    
	    public CreatePostHandler(IAuthenticatedYammerRequestFactory authenticatedYammerRequestFactory)
        {
            _authenticatedYammerRequestFactory = authenticatedYammerRequestFactory;
        }

		public override object OnPost(CreatePostRequest request)
		{
		    var url = "https://www.yammer.com/api/v1/messages?group_id="
		              + GroupMap.GetGroupId(request.ProjectId)
		              + "&body="
		              + HttpUtility.UrlEncode(request.Message);

            HttpWebRequest webRequest;
            try
            {
                webRequest = _authenticatedYammerRequestFactory.CreateAuthenticatedRequest(request.PrincipalId, url);
            }
            catch (Exception e)
            {
                return new HttpResult(HttpStatusCode.Unauthorized, e.Message);
            }

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
	}
}