using OrderManagementSystem.Interfaces;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
	public class RegularCustomerDiscountStrategy : IDiscountStrategy
	{
		public decimal ApplyDiscount(Order order) => order.TotalAmount;
	}
}
