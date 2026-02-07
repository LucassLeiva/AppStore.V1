using System.Text.RegularExpressions;

namespace AppStore.Validators.Entities.Product.UpdateProduct
{
    internal class UpdateProductDtoValidator : AbstractModelValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator(IValidationService<UpdateProductDto> validator)
            : base(validator)
        {
            // IDs
            AddRuleFor(d => d.IdProduct)
                .GreaterThan(0, UpdateProductMessages.IdProductGreaterThanZero);

            AddRuleFor(d => d.IdCategory)
                .GreaterThan(0, UpdateProductMessages.IdCategoryGreaterThanZero);

            AddRuleFor(d => d.IdSupplier)
                .GreaterThan(0, UpdateProductMessages.IdSupplierGreaterThanZero);

            // InternalCode
            AddRuleFor(d => d.InternalCode)
                .StopOnFirstFailure()
                .NotEmpty(UpdateProductMessages.InternalCodeRequired)
                .MaximumLength(50, UpdateProductMessages.InternalCodeMaxLength)
                .Must(code => Regex.IsMatch(code, "^[A-Za-z0-9_-]+$"),
                UpdateProductMessages.InternalCodeInvalidFormat);
            // Name
            AddRuleFor(d => d.Name)
                .NotEmpty(UpdateProductMessages.NameRequired)
                .MaximumLength(150, UpdateProductMessages.NameMaxLength);
               
            // Price
            AddRuleFor(d => d.Price)
                .GreaterThan(0m, UpdateProductMessages.PriceGreaterThanZero);

            // Description
            AddRuleFor(d => d.Description)
                .StopOnFirstFailure()
                .Must(desc => desc is null || !string.IsNullOrWhiteSpace(desc),
                      UpdateProductMessages.DescriptionOnlyWhitespace)
                .MaximumLength(500, UpdateProductMessages.DescriptionMaxLength);
        }
    }
}
