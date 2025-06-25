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
		/// <summary>Updates order status</summary>
		/// <param name="id">Order ID</param>
		/// <param name="newStatus">New status</param>
		/// <returns>Updated order</returns>
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

		[HttpPost("create")]
		[ProducesResponseType(typeof(OrderDto), 200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState); // 400 Bad Request with validation errors
			}

			try
			{

				var order = new Order
				{
					Id = orderDto.Id,
					CustomerId = orderDto.CustomerId,
					CreatedAt = orderDto.CreatedAt,
					DeliveredAt = orderDto.DeliveredAt,
					Status = orderDto.Status,
					TotalAmount = orderDto.TotalAmount
				};
				var createdOrder = await _repo.CreateAsync(order);

				if (createdOrder == null)
					return StatusCode(500, "Failed to create order.");

				return Ok(createdOrder);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("orders-list")]
		[ProducesResponseType(typeof(List<Order>), 200)]
		public async Task<ActionResult<List<Order>>> GetCustomers()
		{
			return Ok(await _repo.ReadAsync());
		}
	}
}
