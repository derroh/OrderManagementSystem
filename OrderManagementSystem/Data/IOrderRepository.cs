using OrderManagementSystem.Dtos;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Data
{
	public interface IOrderRepository
	{
		Task<Order?> GetByIdAsync(int id);
		Task UpdateAsync(Order order);
		Task<OrderAnalyticsDto> GetAnalyticsAsync();
	}
}
