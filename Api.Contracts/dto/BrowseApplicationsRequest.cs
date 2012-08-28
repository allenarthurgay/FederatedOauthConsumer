using Api.Contracts.Dto;

namespace Api.Contracts.DTO
{
	public class BrowseApplicationsRequest : ApplicationRequest
	{
		public string Id { get; set; }
	}
}