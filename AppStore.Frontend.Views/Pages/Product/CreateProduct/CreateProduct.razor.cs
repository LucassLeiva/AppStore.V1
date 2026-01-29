using AppStore.Frontend.Views.ViewModels.Product.CreateProduct;

namespace AppStore.Frontend.Views.Pages.Product.CreateProduct
{
    public partial class CreateProduct
    {
        [Inject]
        CreateProductViewModel ViewModel { get; set; }
        ErrorBoundary ErrorBoundaryRef;

        void Recover()
        {
            ErrorBoundaryRef?.Recover();
        }

    }
}
