using AppStore.Frontend.Views.ViewModels.Product.CreateProduct;

namespace AppStore.Frontend.Views.Components.Product.CreateProduct
{
    public partial class CreateProductComponent
    {
        [Parameter]
        public CreateProductViewModel Product { get; set; } = default!;
        [Parameter]
        public EventCallback OnCancel { get; set; }
    }


}

