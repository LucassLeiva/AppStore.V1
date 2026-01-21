namespace AppStore.Backend.BusinessObjects.POCOEntities
{
    public class Supplier
    {
        public int IdSupplier { get; set; }

        public string Name { get; private set; } = default!;
        public string CUIT { get; private set; } = default!;
        public string Address { get; private set; } = default!;
        public string PhoneNumber { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string City { get; private set; } = default!;
        public string Country { get; private set; } = default!;
        public string Postcode { get; private set; } = default!;
        public int State { get; private set; } = 1;

        protected Supplier() { }

        public Supplier(
            string name,
            string cuit,
            string address,
            string phoneNumber,
            string email,
            string city,
            string country,
            string postcode,
            int state = 1)
        {
            Name = name;
            CUIT = cuit;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            City = city;
            Country = country;
            Postcode = postcode;
            State = state;

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Supplier name is required.");

            if (string.IsNullOrWhiteSpace(CUIT))
                throw new ArgumentException("CUIT is required.");

            if (string.IsNullOrWhiteSpace(Address))
                throw new ArgumentException("Address is required.");

            if (string.IsNullOrWhiteSpace(PhoneNumber))
                throw new ArgumentException("PhoneNumber is required.");

            if (string.IsNullOrWhiteSpace(Email))
                throw new ArgumentException("Email is required.");

            if (string.IsNullOrWhiteSpace(City))
                throw new ArgumentException("City is required.");

            if (string.IsNullOrWhiteSpace(Country))
                throw new ArgumentException("Country is required.");

            if (string.IsNullOrWhiteSpace(Postcode))
                throw new ArgumentException("Postcode is required.");
        }
    }
}
