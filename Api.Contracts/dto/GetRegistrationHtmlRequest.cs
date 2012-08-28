using System;

namespace Api.Contracts.Dto
{
	public class GetRegistrationHtmlRequest : ApplicationRequest
	{
		public Guid PrincipalId { get; set; }

        public string ApplicationId { get; set; }

		public string Service { get; set; }
	}
}
