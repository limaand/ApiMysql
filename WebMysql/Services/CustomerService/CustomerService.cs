
using Microsoft.EntityFrameworkCore;

namespace WebMysql.Services.CustomerService
{
    public class CustomersService : ICustomerService
    {

        private readonly DataContext _context;
        public CustomersService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return await _context.Customers.ToListAsync();
        }

        public async Task<List<Customer>?> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer is null)
                return null;


            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return await _context.Customers.ToListAsync();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer?> GetSingleCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer is null)
                return null;
            return customer;
        }

        public async Task<List<Customer>?> UpdateCustomer(int id, Customer request)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer is null)
                return null;

            customer.name = request.name;
            customer.lastname = request.lastname;
           
            await _context.SaveChangesAsync();


            return await _context.Customers.ToListAsync();
        }
    }
}
