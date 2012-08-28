using System.Collections.Generic;

namespace Api.Contracts.DTO
{
	public class EnumerableResponse<T>
	{
		public List<T> Items { get; set; } 
	}
}
