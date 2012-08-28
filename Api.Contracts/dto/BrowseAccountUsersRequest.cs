using Api.Contracts.Dto;

namespace Api.Contracts.DTO
{
	public class BrowseAccountUsersRequest : ApplicationRequest
	{
		public string Id { get; set; }
	}
}