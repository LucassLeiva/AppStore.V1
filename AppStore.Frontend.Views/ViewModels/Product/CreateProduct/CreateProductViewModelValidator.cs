namespace AppStore.Frontend.Views.ViewModels.Product.CreateProduct
{
    internal class CreateProductViewModelValidator(IModelValidatorHub<CreateProductDto> validator) :
        AbstractViewModelValidator<CreateProductDto, CreateProductViewModel>(validator, ValidationConstraint.AlwaysValidate)
    {
    }
}
