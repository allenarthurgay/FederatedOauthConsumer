using System;

namespace Api.Contracts.dto
{
	public class RegisterServiceTokenRequest
	{
		public Guid PrincipalId { get; set; }
		public string Service { get; set; }
		public string Token { get; set; } 
	}
}
