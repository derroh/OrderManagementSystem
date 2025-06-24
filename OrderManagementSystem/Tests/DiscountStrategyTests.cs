using OrderManagementSystem.Models;
using OrderManagementSystem.Services;
using Xunit;

namespace OrderManagementSystem.Tests
{
	public class DiscountStrategyTests
	{
		[Fact]
		public void VIP_GetDiscountedTotal()
		{
			var strategy = new VipCustomerDiscountStrategy();
			var order = new Order { TotalAmount = 100 };
			var result = strategy.ApplyDiscount(order);
			Assert.Equal(90, result);
		}
	}
}
