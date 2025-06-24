using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Dtos;
using OrderManagementSystem.Enums;
using OrderManagementSystem.Models;
using System;

namespace OrderManagementSystem.Data
{
	public class OrderRepository : IOrderRepository
	{
		private readonly ApplicationDbContext _db;
		public OrderRepository(ApplicationDbContext db) => _db = db;

		public async Task<Order?> GetByIdAsync(int id) =>
			await _db.Orders.Include(o => o.Customer).FirstOrDefaultAsync(o => o.Id == id);

		public async Task UpdateAsync(Order order)
		{
			_db.Orders.Update(order);
			await _db.SaveChangesAsync();
		}

		public async Task<OrderAnalyticsDto> GetAnalyticsAsync()
		{
			var orders = await _db.Orders.Include(o => o.Customer).AsNoTracking().ToListAsync();
			var delivered = orders.Where(o => o.Status == OrderStatus.Delivered && o.DeliveredAt.HasValue);

			return new OrderAnalyticsDto
			{
				AverageOrderValue = orders.Count > 0 ? orders.Average(o => o.TotalAmount) : 0,
				AverageFulfillmentTime = delivered.Any()
					? TimeSpan.FromSeconds(delivered.Average(o => (o.DeliveredAt!.Value - o.CreatedAt).TotalSeconds))
					: TimeSpan.Zero
			};
		}
	}
}
