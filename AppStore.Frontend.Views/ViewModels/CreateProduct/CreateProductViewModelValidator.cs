namespace AppStore.Frontend.Views.ViewModels.CreateProduct
{
    internal class CreateProductViewModelValidator(IModelValidatorHub<CreateProductDto> validator) : 
        AbstractViewModelValidator<CreateProductDto, CreateProductViewModel>(validator,ValidationConstraint.AlwaysValidate)
    {
    }
}
