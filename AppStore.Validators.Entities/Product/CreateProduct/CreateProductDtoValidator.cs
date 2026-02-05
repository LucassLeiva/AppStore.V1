namespace AppStore.Validators.Entities.CreateProduct
{
    internal class CreateProductDtoValidator
       : AbstractModelValidator<CreateProductDto>
    {
        public CreateProductDtoValidator(
            IValidationService<CreateProductDto> validator)
            : base(validator)
        {
            AddRuleFor(p => p.IdCategory)
                .GreaterThan(0, CreateProductMessages.IdCategoryGreaterThanZero);

            AddRuleFor(p => p.IdSupplier)
                .GreaterThan(0, CreateProductMessages.IdSupplierGreaterThanZero);

            AddRuleFor(p => p.InternalCode)
                .NotEmpty(CreateProductMessages.InternalCodeNotEmpty)
                .MaximumLength(50, CreateProductMessages.InternalCodeMaximumLength);

            AddRuleFor(p => p.Name)
                .NotEmpty(CreateProductMessages.NameNotEmpty)
                .MaximumLength(100, CreateProductMessages.NameMaximumLength);

            AddRuleFor(p => p.Price)
                .GreaterThan<decimal>(0, CreateProductMessages.PriceGreaterThanZero);

            AddRuleFor<short>(p => p.StockInicial)
                .GreaterThan((short)0, CreateProductMessages.StockInitialGreaterOrEqualZero);
        }
    }
}
