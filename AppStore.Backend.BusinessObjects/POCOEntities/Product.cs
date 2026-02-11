namespace AppStore.Backend.BusinessObjects.POCOEntities
{
    public class Product
    {
        public int IdProduct { get; set; }

        public int IdCategory { get; set; }

        public string InternalCode { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int IdStock { get; private set; }

        public string? Description { get; set; }

        public int State { get; private set; } = 1;

        public int IdSupplier { get; set; }

        protected Product() { }

        public Product(
            int idCategory,
            string internalCode,
            string name,
            decimal price,
            
            int idSupplier,
            string? description
        )
        {
            IdCategory = idCategory;
            InternalCode = internalCode;
            Name = name;
            Price = price;
            IdSupplier = idSupplier;
            Description = description;

            Validate();

        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(InternalCode))
                throw new ArgumentException("El código interno es obligatorio");

            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("El nombre del producto es obligatorio");

            if (Price <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0(cero)");

            if (IdCategory <= 0)
                throw new ArgumentException("La categoría es obligatoria");

            

            if (IdSupplier <= 0)
                throw new ArgumentException("El proveedor es obligatorio");
        }
        //Asigna el IdStock al producto posteriormente cuando ya tengo el ID
        public void AttachStock(int idStock)
        {
            if (idStock <= 0) throw new ArgumentException("El stock es obligatorio");
            IdStock = idStock;
        }
        public void Deactivate() => State = 0;

        public void Activate() => State = 1;
    }
}
