using Data;

namespace Api.Contracts.Dto
{
	public abstract class ApplicationRequest
	{
		public string AppKey { get; set; }

		public string AppSecret { get; set; }

		public Application Application { get; set; }

		public Account Account { get; set; }
	}
}