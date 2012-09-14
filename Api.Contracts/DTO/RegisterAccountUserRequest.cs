using Api.Contracts.Dto;
using Data;

namespace Api.Contracts.DTO
{
	public class RegisterAccountUserRequest : ApplicationRequest
	{
		public User User { get; set; }
	}
}