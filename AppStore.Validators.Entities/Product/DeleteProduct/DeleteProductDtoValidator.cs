namespace AppStore.Validators.Entities.Product.DeleteProduct
{
    internal class DeleteProductDtoValidator
    : AbstractModelValidator<DeleteProductDto>
    {
        public DeleteProductDtoValidator(
            IValidationService<DeleteProductDto> validator)
            : base(validator)
        {
            AddRuleFor(d => d.IdProduct)
                .GreaterThan(0, DeleteProductMessages.IdProductGreaterThanZero);
        }
    }
}
