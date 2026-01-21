namespace AppStore.Backend.Repositories.Entities
{
    public class ProductEntity
    {
        public int IdProduct { get; set; }
        public int IdCategory { get; set; }
        public CategoryEntity Category { get; set; } = default!;
        public string InternalCode { get; set; } = default!;
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int IdStock { get; set; }
        public StockEntity Stock { get; set; } = default!;
        public string? Description { get; set; }
        public int State { get; set; } = 1;
        public int IdSupplier { get; set; }
        public SupplierEntity Supplier { get; set; } = default!;
    }
}
