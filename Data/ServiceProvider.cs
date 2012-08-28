using System.ComponentModel.DataAnnotations;

namespace Data
{
	public enum AuthenticationType
	{
		OAuth1,
		OAuth2
	}

	public class OAuthConfig
	{
		public string TokenRequestUrl { get; set; }

		public string AuthorizeTokenUrl { get; set; }

		public string AccessTokenUrl { get; set; }
	}

	public class ServiceProvider : DataItem
	{
		[StringLength(500)]
		[Required]
		[Key]
		public string Name { get; set; }

		public AuthenticationType AuthenticationType { get; set; }

		public OAuthConfig AuthConfig { get; set; }


	}
}
