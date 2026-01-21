using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Product
{
    public int IdProduct { get; set; }

    public int IdCategory { get; set; }

    public string InternalCode { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int IdStock { get; set; }

    public string? Description { get; set; }

    public int State { get; set; } = 1;

    public int IdSupplier { get; set; }

    protected Product() { }

    public Product(
        int idCategory,
        string internalCode,
        string name,
        decimal price,
        int idStock,
        int idSupplier,
        string? description
    )
    {
        IdCategory = idCategory;
        InternalCode = internalCode;
        Name = name;
        Price = price;
        IdStock = idStock;
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

        if (Price < 0)
            throw new ArgumentException("El precio no puede ser negativo");

        if (IdCategory <= 0)
            throw new ArgumentException("La categoría es obligatoria");

        if (string.IsNullOrWhiteSpace(InternalCode))
            throw new ArgumentException("El código interno es obligatorio");

        if (IdStock <= 0)
            throw new ArgumentException("El stock es obligatorio");

        if (IdSupplier <= 0)
            throw new ArgumentException("El proveedor es obligatorio");
    }
}
