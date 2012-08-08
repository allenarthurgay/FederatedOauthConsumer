using System;
using System.IO;
using System.Net;
using Api.RestServiceHost.Contracts;
using ServiceStack.ServiceInterface;

namespace Api.RestServiceHost.Handlers
{
	public class GetPostsInGroupHandler : RestServiceBase<GetPostsRequest>
	{
		private static readonly string UserToken = "yRVmP0k8B2qWP6oLTjw";

		public override object OnGet(GetPostsRequest request)
		{
			var groupId = GroupMap.GetGroupId(request.ProjectId);
			var webRequest = CreateRequest("https://www.yammer.com/api/v1/messages/in_group/" + groupId);
			
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

		private HttpWebRequest CreateRequest(string url)
		{
			var webRequest = (HttpWebRequest)WebRequest.Create(url);

			//webRequest.Headers.Add(HttpRequestHeader.Authorization, CreateAuthorizationHeader());
			//webRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer BecS4c1AF3nDwsGujAJP7Q");
			webRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + UserToken);

			return webRequest;
		}

//		private string CreateAuthorizationHeader()
//		{
//			var userToken = UserToken; //TODO: get this
//			var stringToHash = string.Format("OAuth oauth_consumer_key=\"{0}\",oauth_token=\"{1}\",oauth_signature_method=\"HMAC\",oauth_timestamp=\"{2}\",oauth_nonce=\"{2}\",oauth_verifier=\"E4F8\"", AppId, userToken, DateTime.Now.Ticks);
//			return string.Format("{0},oauth_signature=\"{1}\"", stringToHash, CreateSig(userToken, stringToHash));
//		}
//		
//		private string CreateSig(string tokenSecret, string data)
//		{
//			HMACSHA1 hmacsha1 = new HMACSHA1();
//			hmacsha1.Key = Encoding.ASCII.GetBytes(string.Format("{0}&{1}", HttpUtility.UrlEncode(AppId), string.IsNullOrEmpty(tokenSecret) ? "" : HttpUtility.UrlEncode(tokenSecret)));
//
//			byte[] dataBuffer = System.Text.Encoding.ASCII.GetBytes(data);
//			byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
//
//			return Convert.ToBase64String(hashBytes);
//		}
	}
}