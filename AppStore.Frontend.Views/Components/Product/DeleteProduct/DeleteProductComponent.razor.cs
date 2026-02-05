using AppStore.Frontend.Views.ViewModels.Product.DeleteProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Frontend.Views.Components.Product.DeleteProduct
{
    public partial class DeleteProductComponent
    {
        [Parameter] public DeleteProductViewModel Model { get; set; } = default!;
        [Parameter] public int IdProduct { get; set; }
        [Parameter] public string ProductName { get; set; }


        // Para controlar si el Modal se muestra
        [Parameter] public bool Show { get; set; } = true;

        // Eventos
        [Parameter] public EventCallback OnCancel { get; set; }
        [Parameter] public EventCallback<int> OnDeleted { get; set; }

        private bool IsBusy { get; set; }

        private async Task DeleteInternal()
        {
            if (IsBusy) return;

            IsBusy = true;
            try
            {
                await Model.Delete(IdProduct);

                if (OnDeleted.HasDelegate)
                    await OnDeleted.InvokeAsync(IdProduct);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task CancelInternal()
        {
            if (IsBusy) return;

            if (OnCancel.HasDelegate)
                await OnCancel.InvokeAsync();
        }
    }
}

