namespace CustomersAPI.DummyData
{
    public class DummyCustomerData : IDummyCustomerData
    {
        private CustomerDataGenerator _dataGenerator;

        public DummyCustomerData()
        {
            this._dataGenerator = new CustomerDataGenerator();
            this._dataGenerator = new CustomerDataGenerator();
            this.Customers = new List<CustomerTable>();
            this.Names = new List<NameTable>();
            this.Emails = new List<EmailTable>();
            this.Phones = new List<PhoneTable>();
            this._dataGenerator.GenerateRandomData(this, 200);

        }
        public T Execute<T>(Func<List<CustomerTable>, List<NameTable>, List<EmailTable>, List<PhoneTable>, T> query) => query(Customers, Names, Emails, Phones);
        public List<CustomerTable> Customers { get; set; }
        public List<NameTable> Names { get; set; }
        public List<EmailTable> Emails { get; set; }
        public List<PhoneTable> Phones { get; set; }


    }
    public record CustomerTable(int id, int nameId, int emailId, int phoneId);
    public record NameTable(int id, string name);
    public record EmailTable(int id, string email);
    public record PhoneTable(int id, string phone);

}
