namespace CustomersAPI.Application
{
    public class CustomerHelper : ICustomerHelper
    {
        public CustomerRead GetCustomerRead(Customer customer) => new CustomerRead(customer.Name, customer.Email, customer.Phone);
        public CustomerWrite GetCustomerWrite(Customer customer) => new CustomerWrite(customer.Name, customer.Email, customer.Phone);
        public Customer GetCustomer(int id, CustomerRead customer) => new Customer(id, customer.Name, customer.Email, customer.Phone);
        public Customer GetCustomer(int id, CustomerWrite customer) => new Customer(id, customer.Name, customer.Email, customer.Phone);
        public void UpdateCustomer(Customer customer, CustomerRead customerRead)
        {
            customer.Name = customerRead.Name;
            customer.Phone = customerRead.Phone;
            customer.Email = customerRead.Email;
        }
        public void UpdateCustomer(Customer customer, CustomerWrite customerWrite)
        {
            customer.Name = customerWrite.Name;
            customer.Phone = customerWrite.Phone;
            customer.Email = customerWrite.Email;
        }
    }
}
