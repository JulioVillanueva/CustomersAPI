namespace CustomersAPI.DummyData
{
    public class CustomerDataGenerator
    {
        private Random _random;

        public CustomerDataGenerator()
        {
            _random = new Random();
        }

        public string GenerateRandomEmail()
        {
            string[] domains = { "gmail.com", "yahoo.com", "hotmail.com", "outlook.com", "icloud.com" };
            return $"user{_random.Next(1000)}@{domains[_random.Next(domains.Length)]}";
        }

        public string GenerateRandomPhone()
        {
            return "+1-" + _random.Next(100, 999) + "-" + _random.Next(100, 999) + "-" + _random.Next(1000, 9999);
        }

        public string GenerateRandomName()
        {
            string[] names = { "John", "Alice", "Bob", "Emma", "Michael", "Sophia", "David", "Olivia", "James", "Charlotte" };
            string[] lastNames = { "Smith", "Johnson", "Brown", "Taylor", "Lee", "Moore", "Miller", "Wilson", "Davis", "Garcia" };
            return names[_random.Next(names.Length)] + " " + lastNames[_random.Next(lastNames.Length)];
        }

        public void GenerateRandomData(DummyCustomerData data, int customerCount)
        {
            for (int i = 1; i <= customerCount; i++)
            {
                string name = GenerateRandomName();
                string email = GenerateRandomEmail();
                string phone = GenerateRandomPhone();

                data.Customers.Add(new CustomerTable(i, i, i, i));
                data.Names.Add(new NameTable(i, name));
                data.Emails.Add(new EmailTable(i, email));
                data.Phones.Add(new PhoneTable(i, phone));
            }
        }
    }
}
