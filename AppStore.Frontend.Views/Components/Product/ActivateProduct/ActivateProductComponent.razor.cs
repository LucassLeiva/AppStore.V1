namespace AppStore.Frontend.Views.Components.Product.ActivateProduct
{
    public partial class ActivateProductComponent
    {
        [Parameter] public bool Show { get; set; }
        [Parameter] public int IdProduct { get; set; }
        [Parameter] public ActivateProductViewModel Model { get; set; } = default!;

        [Parameter] public EventCallback OnCancel { get; set; }
        [Parameter] public EventCallback OnActivated { get; set; }

        protected bool IsBusy { get; set; }

        private async Task ActivateInternal()
        {
            if (IsBusy) return;

            IsBusy = true;

            await Model.Activate();

            IsBusy = false;

            if (OnActivated.HasDelegate)
                await OnActivated.InvokeAsync();
        }

        private async Task CancelInternal()
        {
            if (OnCancel.HasDelegate)
                await OnCancel.InvokeAsync();
        }
    }
}
