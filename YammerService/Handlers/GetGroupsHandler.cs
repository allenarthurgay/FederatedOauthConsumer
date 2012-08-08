using System;
using System.IO;
using System.Net;
using Api.RestServiceHost.Contracts;
using Api.RestServiceHost.Services;
using ServiceStack.Common.Web;
using ServiceStack.ServiceInterface;

namespace Api.RestServiceHost.Handlers
{
	public class GetGroupsHandler : RestServiceBase<GetGroupsRequest>
	{		
        private readonly IAuthenticatedYammerRequestFactory _authenticatedYammerRequestFactory;
	    
	    public GetGroupsHandler(IAuthenticatedYammerRequestFactory authenticatedYammerRequestFactory)
        {
            _authenticatedYammerRequestFactory = authenticatedYammerRequestFactory;
        }

		public override object OnGet(GetGroupsRequest request)
		{		    
		    var url = "https://www.yammer.com/api/v1/groups/";
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