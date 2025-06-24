using Microsoft.EntityFrameworkCore;

namespace OrderManagementSystem.Models
{
	public class ApplicationDbContext :DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
				
		}
		public DbSet<Order> Orders { get; set; }
		public DbSet<Customer> Customers { get; set; }
	}
}
