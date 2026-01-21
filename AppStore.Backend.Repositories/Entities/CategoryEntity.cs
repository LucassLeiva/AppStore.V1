namespace AppStore.Backend.Repositories.Entities
{
    public class CategoryEntity
    {
        public int IdCategory { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int State { get; set; } = 1;

        // (opcional) navegación si ProductEntity tiene IdCategoria
        public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
