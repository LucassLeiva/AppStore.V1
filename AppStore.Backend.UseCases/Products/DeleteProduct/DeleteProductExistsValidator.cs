namespace AppStore.Backend.UseCases.Products.DeleteProduct
{
    internal class DeleteProductExistsValidator(
    IQueriesRepository repository)
    : IModelValidator<DeleteProductDto>
    {
        private readonly List<ValidationError> errors = [];

        public IEnumerable<ValidationError> Errors => errors;

        public ValidationConstraint Constraint =>
            ValidationConstraint.ValidateIfThereAreNoPreviousErrors;

        public async Task<bool> Validate(DeleteProductDto model)
        {
            errors.Clear();

            var exists = await repository.ProductExists(model.IdProduct);

            if (!exists)
            {
                errors.Add(new ValidationError(
                    nameof(model.IdProduct),
                    DeleteProductMessages.ProductNotFound));
            }

            return !errors.Any();
        }
    }
}
