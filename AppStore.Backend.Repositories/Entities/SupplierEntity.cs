namespace AppStore.Backend.Repositories.Entities
{
    public class SupplierEntity
    {
        public int IdSupplier { get; set; }

        public string Name { get; set; } = default!;
        public string CUIT { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;

        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Postcode { get; set; } = default!;
        public int State { get; set; } = 1;

        // (opcional) navegación si ProductEntity tiene IdProveedor
        public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
