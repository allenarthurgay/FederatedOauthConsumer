using Api.Contracts.Dto;

namespace Api.Contracts.DTO
{
	public class BrowseApplicationServicesRequest : ApplicationRequest
	{
		public string Id { get; set; }
	}
}