namespace CustomersAPI.DummyData
{
    public interface IDummyCustomerData
    {
        T Execute<T>(Func<List<CustomerTable>, List<NameTable>, List<EmailTable>, List<PhoneTable>, T> query) => query(Customers, Names, Emails, Phones);
        List<CustomerTable> Customers { get; set; }
        List<NameTable> Names { get; set; }
        List<EmailTable> Emails { get; set; }
        List<PhoneTable> Phones { get; set; }
    }
}