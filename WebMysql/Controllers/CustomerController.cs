using Microsoft.AspNetCore.Mvc;
using WebMysql.Services.CustomerService;

namespace WebMysql.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            return await _customerService.GetAllCustomers();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetSingleCustomer(int id)
        {
            var result = await _customerService.GetSingleCustomer(id);
            if (result is null)
                return NotFound("Customer not found.");

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer)
        {
            var result = await _customerService.AddCustomer(customer);
            return Ok(result);
        }

    }
}
