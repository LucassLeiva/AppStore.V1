namespace AppStore.Frontend.Views.ViewModels.Product.GetAllProducts
{

    public enum ProductStateFilter
    {
        Active = 0,
        Inactive = 1,
        All = 2
    }

    public class GetAllProductsViewModel(IGetAllProductsGateway gateway)
    {
        #region State
        public IEnumerable<ProductItemDto> Products { get; private set; } = [];
        
        public ProductStateFilter StateFilter { get; set; } = ProductStateFilter.Active;
        public string InformationMessage { get; private set; } = "";
        #endregion

        public async Task Load()
        {
            

            InformationMessage = "";

            try
            {
                var sw = Stopwatch.StartNew();

                bool includeInactive = StateFilter != ProductStateFilter.Active;
                

                var result = await gateway.GetAllAsync(includeInactive);

                sw.Stop(); // ⏹️ frena el cronómetro
                Console.WriteLine($"⏱️ Tiempo carga productos: {sw.ElapsedMilliseconds} ms");

                Products = StateFilter switch
                {
                    ProductStateFilter.Active => result.Where(p => p.State == 1),
                    ProductStateFilter.Inactive => result.Where(p => p.State == 0),
                    _ => result
                };

                if (!Products.Any())
                    InformationMessage = GetAllProductsMessages.EmptyListMessage;
            }
            catch (Exception)
            {
                InformationMessage = GetAllProductsMessages.ErrorLoadingProducts;
            }
            

            
            
        }
        public void SetInformationMessage(string msg)
        {
            InformationMessage = msg;
        }

    }

    }

