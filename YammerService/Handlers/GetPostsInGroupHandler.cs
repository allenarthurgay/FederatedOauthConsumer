using System;
using System.IO;
using System.Net;
using Api.RestServiceHost.Contracts;
using Api.RestServiceHost.Services;
using ServiceStack.Common.Web;
using ServiceStack.ServiceInterface;

namespace Api.RestServiceHost.Handlers
{
	public class GetPostsInGroupHandler : RestServiceBase<GetPostsRequest>
	{
        private readonly IAuthenticatedYammerRequestFactory _authenticatedYammerRequestFactory;

	    public GetPostsInGroupHandler(IAuthenticatedYammerRequestFactory authenticatedYammerRequestFactory)
        {
            _authenticatedYammerRequestFactory = authenticatedYammerRequestFactory;
        }

	    public override object OnGet(GetPostsRequest request)
	    {	       
			var groupId = GroupMap.GetGroupId(request.ProjectId);
	        var url = "https://www.yammer.com/api/v1/messages/in_group/" + groupId;
	        HttpWebRequest webRequest;
            try
            {
                webRequest = _authenticatedYammerRequestFactory.CreateAuthenticatedRequest(request.PrincipalId, url);
            }
            catch(Exception e)
            {
                return new HttpResult(HttpStatusCode.Unauthorized, e.Message);
            }
	        try
			{
				using(var reader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
				{
					return reader.ReadToEnd();
				}
			} catch(Exception e)
			{
				return e;
			}
		}
	}
}