using Api.Contracts.Dto;

namespace Api.Contracts.DTO
{
	public class DeleteApplicationRequest : ApplicationRequest
	{
		public string Id { get; set; }
	}
}