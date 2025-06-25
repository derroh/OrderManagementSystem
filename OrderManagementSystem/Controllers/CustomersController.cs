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
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerRepository _repo;

		public CustomersController(ICustomerRepository repo) => _repo = repo;

		[HttpPost("create")]
		[ProducesResponseType(typeof(Customer), 200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState); // 400 Bad Request with validation errors
			}

			try
			{
				var createdCustomer = await _repo.CreateAsync(customer);

				if (createdCustomer == null)
					return StatusCode(500, "Failed to create customer.");

				return Ok(createdCustomer); 
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("customers-list")]
		[ProducesResponseType(typeof(List<Customer>), 200)]
		public async Task<ActionResult<List<Customer>>> GetCustomers()
		{
			return Ok(await _repo.ReadAsync());
		}
	}
}
