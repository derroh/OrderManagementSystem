using OrderManagementSystem.Interfaces;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
	public class LoyalCustomerDiscountStrategy : IDiscountStrategy
	{
		public decimal ApplyDiscount(Order order) => order.TotalAmount * 0.95m;
	}
}
