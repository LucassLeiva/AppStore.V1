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
                .StopOnFirstFailure()
                .NotEmpty(CreateProductMessages.InternalCodeNotEmpty)
                .MaximumLength(50, CreateProductMessages.InternalCodeMaximumLength)
                .Must(code => Regex.IsMatch(code, "^[A-Za-z0-9_-]+$"),
                CreateProductMessages.InternalCodeInvalidFormat);

            AddRuleFor(p => p.Name)
                .NotEmpty(CreateProductMessages.NameNotEmpty)
                .MaximumLength(100, CreateProductMessages.NameMaximumLength);

            AddRuleFor(p => p.Price)
                .GreaterThan<decimal>(0, CreateProductMessages.PriceGreaterThanZero);

            AddRuleFor<short>(p => p.StockInicial)
                .Must(s => s >= 0, CreateProductMessages.StockInitialGreaterOrEqualZero);

            AddRuleFor(d => d.Description)
                .StopOnFirstFailure()
                .Must(desc => desc is null || !string.IsNullOrWhiteSpace(desc),
                      CreateProductMessages.DescriptionOnlyWhitespace)
                .MaximumLength(500, CreateProductMessages.DescriptionMaximumLength);
        }
    }
}
