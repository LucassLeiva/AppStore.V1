namespace AppStore.Entities.DTOs.Products.UpdateProductWithStock
{
    public class UpdateProductWithStockDto
    (
        int idProduct,
        int idCategory,
        string internalCode,
        string name,
        decimal price,
        string? description,
        int idSupplier,
        int stockAmount
    )
    {
    public int IdProduct => idProduct;
    public int IdCategory => idCategory;
    public string InternalCode => internalCode;
    public string Name => name;
    public decimal Price => price;
    public string Description => description;
    public int IdSupplier => idSupplier;
    public int StockAmount => stockAmount;
}
}
