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
	public class CreateGroupHandler : RestServiceBase<CreateGroupRequest>
	{		
        private readonly IAuthenticatedYammerRequestFactory _authenticatedYammerRequestFactory;
	    
	    public CreateGroupHandler(IAuthenticatedYammerRequestFactory authenticatedYammerRequestFactory)
        {
            _authenticatedYammerRequestFactory = authenticatedYammerRequestFactory;
        }

        public override object OnPost(CreateGroupRequest request)
		{
			if (!string.IsNullOrEmpty(GroupMap.GetGroupId(request.ProjectId)))
			{
				throw new Exception("Group already exists for project id " + request.ProjectId);
			}

            var url = "https://www.yammer.com/api/v1/groups/?private=true&name=" + HttpUtility.UrlEncode(request.Name);
            HttpWebRequest webRequest;
            try
            {
                webRequest = _authenticatedYammerRequestFactory.CreateAuthenticatedRequest(request.PrincipalId, url);
            }
            catch (Exception e)
            {
                return new HttpResult(HttpStatusCode.Unauthorized, e.Message);
            }
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