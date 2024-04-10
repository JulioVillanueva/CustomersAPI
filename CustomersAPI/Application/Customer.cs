namespace CustomersAPI.Application
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Customer(int Id, string Name, string Email, string Phone)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
        }

        public Customer()
        {
        }
    }
}
