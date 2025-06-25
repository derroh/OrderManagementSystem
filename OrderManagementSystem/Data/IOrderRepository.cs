using OrderManagementSystem.Dtos;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Data
{
	public interface IOrderRepository
	{
		Task<Order?> GetByIdAsync(int id);
		Task <Order> CreateAsync(Order order);
		Task UpdateAsync(Order order);
		Task<OrderAnalyticsDto> GetAnalyticsAsync();
		Task<List<Order>> ReadAsync();
	}
}
