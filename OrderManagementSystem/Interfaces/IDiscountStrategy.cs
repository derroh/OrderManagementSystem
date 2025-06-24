using OrderManagementSystem.Models;

namespace OrderManagementSystem.Interfaces
{
	public interface IDiscountStrategy
	{
		decimal ApplyDiscount(Order order);
	}
}
