using OrderManagementSystem.Interfaces;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
	public class DiscountContext
	{
		public IDiscountStrategy Resolve(Customer customer)
		{
			return customer.Segment switch
			{
				Enums.CustomerSegment.VIP => new VipCustomerDiscountStrategy(),
				Enums.CustomerSegment.Loyal => new LoyalCustomerDiscountStrategy(),
				_ => new RegularCustomerDiscountStrategy()
			};
		}
	}
}
