namespace Api.Contracts.dto
{
	public class GetRegistrationHtmlResponse
    {
        public string AppId { get; set; }

        public string PrincipalId { get; set; }

        public string Service { get; set; }    

		public string Html { get; set; }

        public string ScriptUrlRoot { get; set; }
	}
}
