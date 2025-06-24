using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace OrderManagementSystem.Tests
{
	public class OrdersIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
	{
		private readonly HttpClient _client;

		public OrdersIntegrationTests(WebApplicationFactory<Program> factory)
		{
			_client = factory.CreateClient();
		}

		[Fact]
		public async Task UpdateOrderStatus_ReturnsSuccess()
		{
			var response = await _client.PutAsJsonAsync("/orders/1/status", new { status = "Processing" });
			response.EnsureSuccessStatusCode();
		}
	}

}
