using CustomersAPI.Application;

namespace CustomersAPI.Infrastructure
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        IEnumerable<Customer> GetCustomersByName(string name);
        Customer CreateNewCustomer(CustomerWrite newCustomer);
    }
}
