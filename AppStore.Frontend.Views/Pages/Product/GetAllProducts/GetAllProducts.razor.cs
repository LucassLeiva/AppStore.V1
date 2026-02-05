using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AppStore.Frontend.Views.ViewModels.Product.GetAllProducts;

namespace AppStore.Frontend.Views.Pages.Product.GetAllProducts
{
    public partial class GetAllProducts
    {
        [Inject] GetAllProductsViewModel ViewModel { get; set; } = default!;
        [Inject] NavigationManager Nav { get; set; } = default!;

        [Parameter, SupplyParameterFromQuery]
        public string? Msg { get; set; }

        ErrorBoundary? ErrorBoundaryRef;

        void Recover()
        {
            ErrorBoundaryRef?.Recover();
        }
        protected override async Task OnParametersSetAsync()
        {
            await ViewModel.Load();

            if (!string.IsNullOrWhiteSpace(Msg))
            {
                ViewModel.SetInformationMessage(Msg);
            }
        }

        //protected override async Task OnInitializedAsync()
        //{
        //    await ViewModel.Load();
        //}

        private void GoToCreate()
        {
            Nav.NavigateTo("/createproduct");
        }

        private void GoToEdit(int idProduct)
        {
            Nav.NavigateTo($"/products/update/{idProduct}");

        }
        private void GoToDelete(int idProduct)
        {
            Nav.NavigateTo($"/products/delete/{idProduct}");
        }
        private void GoToActivate(int idProduct)
        {
            Nav.NavigateTo($"/products/activate/{idProduct}");
        }

    }
}
