namespace AppStore.Backend.UseCases.Products.ActivateProduct
{
    internal class ActivateProductExistsValidator( IQueriesRepository repository)  : IModelValidator<ActivateProductDto>
        {
            private readonly List<ValidationError> errors = [];

            public IEnumerable<ValidationError> Errors => errors;

            public ValidationConstraint Constraint =>
                ValidationConstraint.ValidateIfThereAreNoPreviousErrors;

            public async Task<bool> Validate(ActivateProductDto model)
            {
                errors.Clear();

                var exists = await repository.ProductExists(model.IdProduct);

                if (!exists)
                {
                    errors.Add(new ValidationError(
                        nameof(model.IdProduct),
                        ActivateProductMessages.ProductNotFound));
                }

                return !errors.Any();
            }
        }
    
}
