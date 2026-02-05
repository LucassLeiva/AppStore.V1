using Microsoft.AspNetCore.Components;
using AppStore.Frontend.Views.ViewModels.Product.ActivateProduct;

namespace AppStore.Frontend.Views.Pages.Product.ActivateProduct
{
    public partial class ActivateProduct
    {
        [Parameter] public int IdProduct { get; set; }

        [Inject] public ActivateProductViewModel ViewModel { get; set; } = default!;
        [Inject] public NavigationManager Nav { get; set; } = default!;

        ErrorBoundary? ErrorBoundaryRef;

        void Recover() => ErrorBoundaryRef?.Recover();

        protected override async Task OnParametersSetAsync()
        {
            // Cargar datos del producto a activar (para mostrar nombre, etc.)
            await ViewModel.Load(IdProduct);
        }

        private void GoBack()
            => Nav.NavigateTo("/getallproducts");

        private async Task AfterActivated()
        {
            //se almacena el mensaje en la variable msg
            var msg = Uri.EscapeDataString(ViewModel.InformationMessage);
            //se envia la variable msg
            Nav.NavigateTo($"/getallproducts?msg={msg}");
            await Task.CompletedTask;
        }
    }
}