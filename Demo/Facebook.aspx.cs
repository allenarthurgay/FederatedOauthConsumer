using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace Demo
{
	public partial class Facebook : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.QueryString.AllKeys.Length == 0)
			{
				MyPlaceHolder.Controls.Add(new HyperLink()
				                           	{
				                           		NavigateUrl =
				                           			"https://www.facebook.com/dialog/oauth?client_id=352351538166944&redirect_uri=http://localhost:4199/Facebook.aspx&state=MYSTATE",
				                           		Text = "Facebook"
				                           	});
				return;
			}

			if (Request.QueryString["code"] != null)
			{
				var code = Request.QueryString["code"];

				var request = WebRequest.Create(String.Format("https://graph.facebook.com/oauth/access_token?client_id=352351538166944&redirect_uri=http://localhost:4199/Facebook.aspx&client_secret=9d84e5dcdc398b016793262e2de6a29f&code={0}", code));
				var response = (HttpWebResponse) request.GetResponse();

				Stream dataStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(dataStream);
				string responseFromServer = reader.ReadToEnd();

				var token = responseFromServer.Split('&')[0].Split('=')[1];

				request = WebRequest.Create(String.Format("https://graph.facebook.com/me?access_token={0}", token));
				response = (HttpWebResponse)request.GetResponse();

				dataStream = response.GetResponseStream();
				reader = new StreamReader(dataStream);
				responseFromServer = reader.ReadToEnd();

				MyPlaceHolder.Controls.Add(new LiteralControl(responseFromServer));
			}
		}
	}
}