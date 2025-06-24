using OrderManagementSystem.Enums;

namespace OrderManagementSystem.Models
{
	public class Customer
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public CustomerSegment Segment { get; set; }
	}
}
