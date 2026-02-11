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
            IdProduct = 0;
            ProductName = "";

            try
            {
                var product = await getProductGateway.GetByIdAsync(idProduct);

                IdProduct = product.IdProduct;
                ProductName = product.Name;
            }
            catch (HttpRequestException ex)
            {
                InformationMessage = ex.Message;
            }
        }

        public async Task<bool> Activate()
        {
            InformationMessage = "";

            await gateway.ActivateAsync(IdProduct);

            try
            {
                await gateway.ActivateAsync(IdProduct);

                InformationMessage = string.Format(
                    ActivateProductMessages.ActivatedProductTemplate,
                    ProductName);

                return true;
            }
            catch (HttpRequestException ex)
            {
                InformationMessage = ex.Message;
                return false;
            }
        }
    }
}
