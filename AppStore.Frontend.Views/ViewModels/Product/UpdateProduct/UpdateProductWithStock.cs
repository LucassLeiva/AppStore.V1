namespace AppStore.Frontend.Views.ViewModels.Product.UpdateProduct
{
    internal class UpdateProductWithStockViewModelValidator(IModelValidatorHub<UpdateProductWithStockDto> validator) : AbstractViewModelValidator<UpdateProductWithStockDto, UpdateProductViewModel>(
             validator, ValidationConstraint.AlwaysValidate)
    {

    }
}
