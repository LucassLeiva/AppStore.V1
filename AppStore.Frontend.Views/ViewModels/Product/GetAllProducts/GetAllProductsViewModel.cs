
namespace AppStore.Frontend.Views.ViewModels.Product.GetAllProducts
{
    public class GetAllProductsViewModel(IGetAllProductsGateway gateway)
    {
        #region State
        public IEnumerable<ProductItemDto> Products { get; private set; } = [];
        public bool IncludeInactive { get; set; } = false;
        public string InformationMessage { get; private set; } = "";
        #endregion

        public async Task Load()
        {
            InformationMessage = "";

            try
            {
                Products = await gateway.GetAllAsync(IncludeInactive);

                if (!Products.Any())
                {
                    InformationMessage = GetAllProductsMessages.EmptyListMessage;
                }
            }
            catch (Exception)
            {
                InformationMessage = GetAllProductsMessages.ErrorLoadingProducts;
            }
        }
    }
}
