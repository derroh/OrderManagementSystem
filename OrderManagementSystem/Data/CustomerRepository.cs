using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Data
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly ApplicationDbContext _db;
		public CustomerRepository(ApplicationDbContext db) => _db = db;
		public async Task<Customer> CreateAsync(Customer customer)
		{
			_db.Customers.Add(customer);
			await _db.SaveChangesAsync();
			return customer;
		}

		public async Task<List<Customer>> ReadAsync()
		{
			var customers = await _db.Customers.ToListAsync();

			return customers ?? new List<Customer>();
		}
	}
}
