namespace Api.Contracts.Dto
{
	public abstract class ApplicationRequest
	{
		public string AppKey { get; set; }

		public string AppSecret { get; set; }
	}
}