using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Data;
using OrderManagementSystem.Dtos;
using OrderManagementSystem.Enums;
using OrderManagementSystem.Models;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderRepository _repo;
		private readonly DiscountContext _discountContext = new();

		public OrdersController(IOrderRepository repo) => _repo = repo;

		[HttpPut("{id}/status")]
		[ProducesResponseType(typeof(Order), 200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> UpdateStatus(int id, [FromBody] OrderStatus newStatus)
		{
			var order = await _repo.GetByIdAsync(id);
			if (order == null) return NotFound();

			if (!OrderStatusTransitions.CanTransition(order.Status, newStatus))
				return BadRequest("Invalid transition");

			order.Status = newStatus;
			if (newStatus == OrderStatus.Delivered)
				order.DeliveredAt = DateTime.UtcNow;

			await _repo.UpdateAsync(order);
			return Ok(order);
		}

		[HttpGet("analytics")]
		[ProducesResponseType(typeof(OrderAnalyticsDto), 200)]
		public async Task<ActionResult<OrderAnalyticsDto>> GetAnalytics()
		{
			return Ok(await _repo.GetAnalyticsAsync());
		}
	}
}
