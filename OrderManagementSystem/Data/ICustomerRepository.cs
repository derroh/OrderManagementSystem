using OrderManagementSystem.Dtos;
using OrderManagementSystem.Models;
using System.Threading.Tasks;

namespace OrderManagementSystem.Data
{
	public interface ICustomerRepository
	{
		Task<List<Customer>> ReadAsync();
		Task <Customer> CreateAsync(Customer customer);
	}
}
