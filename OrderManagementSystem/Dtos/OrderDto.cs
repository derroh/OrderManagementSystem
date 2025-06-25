using OrderManagementSystem.Enums;

namespace OrderManagementSystem.Dtos
{
	public class OrderDto
	{
		public int CustomerId { get; set; }
		public int Id { get; set; }
		public decimal TotalAmount { get; set; }
		public OrderStatus Status { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? DeliveredAt { get; set; }
	}
}
