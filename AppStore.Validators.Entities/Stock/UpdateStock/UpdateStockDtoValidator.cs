namespace AppStore.Validators.Entities.Stock.UpdateStock
{
    internal class UpdateStockDtoValidator : AbstractModelValidator<UpdateStockDto>
    {
        public UpdateStockDtoValidator(IValidationService<UpdateStockDto> validator)
            : base(validator)
        {
            AddRuleFor(d => d.IdProduct)
                .GreaterThan(0, UpdateStockMessages.IdProductGreaterThanZero);

            AddRuleFor(d => d.Amount)
                .Must(a => a >= 0, UpdateStockMessages.AmountCannotBeNegative);
        }
    }
}
