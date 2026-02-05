namespace AppStore.Frontend.Views.Pages.Product.CreateProduct
{
    public partial class CreateProduct
    {
        [Inject]
        CreateProductViewModel ViewModel { get; set; }
        [Inject] 
        NavigationManager Nav { get; set; }
        ErrorBoundary ErrorBoundaryRef;

        void Recover()
        {
            ErrorBoundaryRef?.Recover();
        }
        protected override async Task OnInitializedAsync()
        {
            await ViewModel.LoadCombos();
        }
        private void GoToGetAllProducts()
        {
            Nav.NavigateTo("/getallproducts");
        }
    }
}
