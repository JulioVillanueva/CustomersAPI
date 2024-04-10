using CustomersAPI.Application;
using CustomersAPI.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CustomersAPI.Controllers
{
    [Route("Customers")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomersRepository _customerRepository;

        public CustomersController(ICustomersRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public Results<Ok<IEnumerable<Customer>>, BadRequest> GetCustomers()
        {
            var list = this._customerRepository.GetCustomers();
            if (list == null)
                return TypedResults.BadRequest();
            return TypedResults.Ok(list);
        }

        [HttpGet]
        [Route("{id:int}")]
        public Results<Ok<Customer>, NotFound, BadRequest> GetCustomer([FromRoute] int id)
        {
            var customer = this._customerRepository.GetCustomerById(id);
            if (customer == null)
                return TypedResults.NotFound();
            return TypedResults.Ok(customer);
        }
        [HttpGet]
        [Route("names/{name}")]
        public Results<Ok<IEnumerable<Customer>>, BadRequest> GetCustomer([FromRoute] string name)
        {
            var customer = this._customerRepository.GetCustomersByName(name);
            if (customer == null)
                return TypedResults.BadRequest();
            return TypedResults.Ok(customer);
        }
        [HttpPut]
        public Results<Created<Customer>, BadRequest> GetCustomer([FromBody] CustomerWrite newCustomer)
        {
            Customer customer = this._customerRepository.CreateNewCustomer(newCustomer);
            if (customer == null)
                return TypedResults.BadRequest();
            else
                return TypedResults.Created("", customer);
        }
    }
}
