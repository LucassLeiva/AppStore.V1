namespace AppStore.Frontend.Views.Pages
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
