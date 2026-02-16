namespace AppStore.Backend.UseCases.Products.UpdateProductWithStock
{
    internal class UpdateProductWithStockProductExistsValidator(IQueriesRepository repository)
    : IModelValidator<UpdateProductWithStockDto>
    {
        private readonly List<ValidationError> errors = [];
        public IEnumerable<ValidationError> Errors => errors;

        public ValidationConstraint Constraint =>
            ValidationConstraint.ValidateIfThereAreNoPreviousErrors;

        public async Task<bool> Validate(UpdateProductWithStockDto model)
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
