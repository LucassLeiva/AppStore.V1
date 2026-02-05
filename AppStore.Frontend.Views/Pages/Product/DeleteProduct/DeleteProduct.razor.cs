using AppStore.Frontend.Views.ViewModels.Product.DeleteProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Frontend.Views.Pages.Product.DeleteProduct
{
    public partial class DeleteProduct
    {
        [Parameter] public int IdProduct { get; set; }
       



        [Inject] public DeleteProductViewModel ViewModel { get; set; } = default!;
        [Inject] public NavigationManager Nav { get; set; } = default!;

        ErrorBoundary? ErrorBoundaryRef;

        void Recover() => ErrorBoundaryRef?.Recover();

        private void GoBack()
        {
            Nav.NavigateTo("/getallproducts");
        }

        private Task AfterDeleted(int idProduct)
        {
            var msg = Uri.EscapeDataString(ViewModel.InformationMessage);
            Nav.NavigateTo($"/getallproducts?msg={msg}");
            return Task.CompletedTask;
        }
        protected override async Task OnParametersSetAsync()
        {
            await ViewModel.Load(IdProduct);
        }
    }
}
