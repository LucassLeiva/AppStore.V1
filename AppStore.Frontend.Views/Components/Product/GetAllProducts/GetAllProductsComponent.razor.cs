namespace AppStore.Frontend.Views.Components.Product.GetAllProducts
{
    public partial class GetAllProductsComponent
    {
        [Parameter]
        public GetAllProductsViewModel Products { get; set; } = default!;
        [Parameter]
        public EventCallback OnCreate { get; set; }
        [Parameter]
        public EventCallback<int> OnEdit { get; set; }
        [Parameter]
        public EventCallback<int> OnDelete { get; set; }
        [Parameter]
        public EventCallback<int> OnActivate { get; set; }


        private Task Create()
            => OnCreate.HasDelegate ? OnCreate.InvokeAsync() : Task.CompletedTask;

        private Task Edit(int idProduct)
            => OnEdit.HasDelegate ? OnEdit.InvokeAsync(idProduct) : Task.CompletedTask;

        private Task Delete(int idProduct)
            => OnDelete.HasDelegate ? OnDelete.InvokeAsync(idProduct) : Task.CompletedTask;

        private Task Activate(int idProduct)
            => OnActivate.HasDelegate ? OnActivate.InvokeAsync(idProduct) : Task.CompletedTask;

        private async Task OnFilterChanged()
        {
            
            await Products.Load();
        }


    }
}