using WebMysql.Models;

namespace WebMysql.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer?> GetSingleCustomer(int id);
        Task<List<Customer>> AddCustomer(Customer customer);
        Task<List<Customer>?> UpdateCustomer(int id, Customer request);
        Task<List<Customer>?> DeleteCustomer(int id);
    }
}
