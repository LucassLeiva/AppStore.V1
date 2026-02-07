namespace AppStore.Validators.Entities.Product.ActivateProduct
{
    internal class ActivateProductDtoValidator
    : AbstractModelValidator<ActivateProductDto>
    {
        public ActivateProductDtoValidator(
            IValidationService<ActivateProductDto> validator)
            : base(validator)
        {
            AddRuleFor(d => d.IdProduct)
                .GreaterThan(0, ActivateProductMessages.IdProductGreaterThanZero);
        }
    }
}
