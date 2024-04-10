using CustomersAPI.Application;
using CustomersAPI.DummyData;

namespace CustomersAPI.Infrastructure
{
    public class CustomersInMemoryRepository : ICustomersRepository
    {
        private IDummyCustomerData _data;
        private readonly ICustomerHelper _custHelper;

        public CustomersInMemoryRepository(IDummyCustomerData data, ICustomerHelper custHelper)
        {
            _data = data;
            _custHelper = custHelper;
        }


        public IEnumerable<Customer> GetCustomers()
        {
            IEnumerable<Customer> customers = GetCustomerList();
            return customers.ToList();
        }
        public Customer? GetCustomerById(int id)
        {
            var customer = GetCustomerList().FirstOrDefault(c => c.Id == id);
            return customer;
        }
        public Customer? CreateNewCustomer(int id)
        {
            var customer = GetCustomerList().FirstOrDefault(c => c.Id == id);
            return customer;
        }
        public IEnumerable<Customer> GetCustomersByName(string name)
        {
            var customers = GetCustomerList().Where(c => c.Name.Contains(name)).ToList();
            return customers;
        }
        public Customer CreateNewCustomer(CustomerWrite newCustomer)
        {
            Customer customer = GetNewCustomer(newCustomer);
            InsertCustomer(customer);
            return customer;
        }



        private IEnumerable<Customer> GetCustomerList()
        {
            return from customer in _data.Customers
                   join name in _data.Names
                       on customer.nameId equals name.id
                   join email in _data.Emails
                       on customer.emailId equals email.id
                   join phone in _data.Phones
                       on customer.phoneId equals phone.id
                   select new Customer
                   {
                       Id = customer.id,
                       Name = name.name,
                       Email = email.email,
                       Phone = phone.phone
                   };
        }
        private IEnumerable<Customer> InsertCustomers(IEnumerable<CustomerWrite> newCustomers)
        {
            var list = new List<Customer>();
            int nextId = GetNextId();
            foreach (var newCustomer in newCustomers)
            {
                var customer = GetNewCustomer(nextId, newCustomer);
                InsertCustomer(customer);
                list.Add(customer);
                nextId++;
            }
            return list;
        }
        private Customer GetNewCustomer(CustomerWrite newCustomer)
        {
            var nextId = GetNextId();
            var customer = _custHelper.GetCustomer(nextId, newCustomer);
            return customer;
        }
        private Customer GetNewCustomer(int id, CustomerWrite newCustomer)
        {
            var customer = _custHelper.GetCustomer(id, newCustomer);
            return customer;
        }
        private int GetNextId()
        {//semaphore
            return _data.Customers.Max(c => c.id) + 1;
        }

        private void InsertCustomer(Customer customer)
        {
            _data.Customers.Add(new CustomerTable(customer.Id, customer.Id, customer.Id, customer.Id));
            _data.Names.Add(new NameTable(customer.Id, customer.Name));
            _data.Emails.Add(new EmailTable(customer.Id, customer.Email));
            _data.Phones.Add(new PhoneTable(customer.Id, customer.Phone));
        }
    }
}
