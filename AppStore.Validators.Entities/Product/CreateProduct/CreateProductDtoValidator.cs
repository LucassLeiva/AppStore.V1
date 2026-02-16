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
                .StopOnFirstFailure()
                .Must(s => s >= 0, CreateProductMessages.StockInitialGreaterOrEqualZero)
                .Must(s => s <= short.MaxValue, CreateProductMessages.StockInitialLessOrEqualMaxValue);

            AddRuleFor(d => d.Description)
                .StopOnFirstFailure()
                .Must(desc => desc is null || desc.Length == 0 || !string.IsNullOrWhiteSpace(desc),
                    CreateProductMessages.DescriptionOnlyWhitespace)
                .MaximumLength(500, CreateProductMessages.DescriptionMaximumLength);
        }
    }
}
