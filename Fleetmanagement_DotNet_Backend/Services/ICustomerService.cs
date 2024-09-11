
using FM.Modles;

namespace Fleets.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(long id);
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task<Customer> GetCustomerByEmailAsync(string email);
        Task<bool> ValidateCustomerLoginAsync(string email, string password);
        Task DeleteCustomerAsync(long id);
    }
}