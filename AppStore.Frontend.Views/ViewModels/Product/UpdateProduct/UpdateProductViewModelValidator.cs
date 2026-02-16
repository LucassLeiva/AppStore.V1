using AppStore.Entities.DTOs.Products.UpdateProductWithStock;

namespace AppStore.Frontend.Views.ViewModels.Product.UpdateProduct
{
    internal class UpdateProductViewModelValidator(IModelValidatorHub<UpdateProductDto> validator) :
                   AbstractViewModelValidator<UpdateProductDto, UpdateProductViewModel>(validator, ValidationConstraint.AlwaysValidate)
    {

    }
}
