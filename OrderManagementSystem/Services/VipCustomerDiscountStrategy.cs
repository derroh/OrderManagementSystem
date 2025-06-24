using OrderManagementSystem.Interfaces;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
	public class VipCustomerDiscountStrategy : IDiscountStrategy
	{
		public decimal ApplyDiscount(Order order) => order.TotalAmount * 0.90m;
	}
}
