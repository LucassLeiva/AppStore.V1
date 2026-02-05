namespace AppStore.Frontend.Views.Pages.Product.UpdateProduct
{
    public partial class UpdateProduct
    {
        [Inject] UpdateProductViewModel ViewModel { get; set; } = default!;
        [Inject] NavigationManager Nav { get; set; } = default!;

        ErrorBoundary? ErrorBoundaryRef;

        protected override async Task OnParametersSetAsync()
        {
            await ViewModel.Load(idProduct);
        }

        void Recover() => ErrorBoundaryRef?.Recover();

        private void GoBack()
        {
            // ajustá a tu ruta del listado si es otra
            Nav.NavigateTo("/getallproducts");
        }
    }
}
