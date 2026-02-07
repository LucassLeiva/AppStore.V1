namespace AppStore.Backend.UseCases.Stocks.UpdateStock
{
    internal class UpdateStockProductExistsValidator(IQueriesRepository repository)
    : IModelValidator<UpdateStockDto>
    {
        private readonly List<ValidationError> errors = [];
        public IEnumerable<ValidationError> Errors => errors;

        public ValidationConstraint Constraint =>
            ValidationConstraint.ValidateIfThereAreNoPreviousErrors;

        public async Task<bool> Validate(UpdateStockDto model)
        {
            errors.Clear();

            var exists = await repository.ProductExists(model.IdProduct);
            if (!exists)
            {
                errors.Add(new ValidationError(
                    nameof(model.IdProduct),
                    UpdateStockMessages.ProductNotFound
                ));
            }

            return !errors.Any();
        }
    }
}
