namespace CustomersAPI.Application
{
    public interface ICustomerHelper
    {
        CustomerRead GetCustomerRead(Customer customer);
        CustomerWrite GetCustomerWrite(Customer customer);
        void UpdateCustomer(Customer customer, CustomerRead customerRead);
        void UpdateCustomer(Customer customer, CustomerWrite customerWrite);
        Customer GetCustomer(int id, CustomerRead customer);
        Customer GetCustomer(int id, CustomerWrite customer);
    }
}