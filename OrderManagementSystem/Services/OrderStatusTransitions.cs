using OrderManagementSystem.Enums;

namespace OrderManagementSystem.Services
{
	public class OrderStatusTransitions
	{
		private static readonly Dictionary<OrderStatus, OrderStatus[]> _map = new()
		{
			[OrderStatus.Pending] = new[] { OrderStatus.Processing, OrderStatus.Cancelled },
			[OrderStatus.Processing] = new[] { OrderStatus.Shipped },
			[OrderStatus.Shipped] = new[] { OrderStatus.Delivered },
		};

		public static bool CanTransition(OrderStatus current, OrderStatus next) =>
			_map.TryGetValue(current, out var valid) && valid.Contains(next);
	}
}
