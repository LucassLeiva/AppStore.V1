namespace AppStore.Frontend.Views.Components.Product.UpdateProduct
{
    public partial class UpdateProductComponent
    {
        [Parameter, EditorRequired]
        public UpdateProductViewModel Model { get; set; } = default!;

        // Eventos: la Page decide la navegación
        [Parameter] public EventCallback OnCancel { get; set; }

        private async Task SaveInternal()
        {
            await Model.Save();

        }
        

        private Task Cancel()
            => OnCancel.HasDelegate ? OnCancel.InvokeAsync() : Task.CompletedTask;

    }
}