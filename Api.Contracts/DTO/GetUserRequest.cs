using Api.Contracts.Dto;

namespace Api.Contracts.DTO
{
	public class GetUserRequest: ApplicationRequest
	{
		public int Id { get; set; }

		public string UserId { get; set; }
	}
}