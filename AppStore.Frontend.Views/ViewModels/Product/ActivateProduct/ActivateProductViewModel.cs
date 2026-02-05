namespace AppStore.Frontend.Views.ViewModels.Product.ActivateProduct
{
    public class ActivateProductViewModel(
    IActivateProductGateway gateway,
    IGetProductByIdGateway getProductGateway)
    {
        public int IdProduct { get; private set; }
        public string ProductName { get; private set; } = "";
        public string InformationMessage { get; private set; } = "";

        public async Task Load(int idProduct)
        {
            InformationMessage = "";
            var product = await getProductGateway.GetByIdAsync(idProduct);

            IdProduct = product.IdProduct;
            ProductName = product.Name;
        }

        public async Task Activate()
        {
            await gateway.ActivateAsync(IdProduct);

            InformationMessage =
                string.Format(
                    ActivateProductMessages.ActivatedProductTemplate,
                    ProductName);
        }
    }
}
