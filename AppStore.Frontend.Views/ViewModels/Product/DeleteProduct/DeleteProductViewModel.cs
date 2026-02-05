namespace AppStore.Frontend.Views.ViewModels.Product.DeleteProduct
{
    public class DeleteProductViewModel(IDeleteProductGateway gateway, IGetProductByIdGateway getbyidGateway)
    {
        public string InformationMessage { get; private set; } = "";
        public int IdProduct { get; private set; }
        public string ProductName { get; private set; } = "";

        public async Task Load(int idProduct)
        {
            InformationMessage = "";

            var product = await getbyidGateway.GetByIdAsync(idProduct);

            IdProduct = product.IdProduct;
            ProductName = product.Name;
        }
        public async Task Delete(int idProduct)
        {
            InformationMessage = "";

            await gateway.DeleteAsync(IdProduct);

            InformationMessage = string.Format(
                DeleteProductMessages.DeletedProductTemplate,
                ProductName);
        }
    }
}
