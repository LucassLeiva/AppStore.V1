namespace AppStore.Backend.UseCases.CreateProduct
{
    internal class CreateProductCategoryValidator(
        IQueriesRepository repository) : IModelValidator<CreateProductDto>
    {
        readonly List<ValidationError> ErrorsField = [];
        public IEnumerable<ValidationError> Errors => ErrorsField;

        public ValidationConstraint Constraint =>
            ValidationConstraint.ValidateIfThereAreNoPreviousErrors;

        public async Task<bool> Validate(CreateProductDto model)
        {
            var categories = await repository.GetAvailableCategories();

            bool exists = categories.Any(c => c.IdCategory == model.IdCategory);
            if (!exists)
            {
                ErrorsField.Add(new ValidationError(
                    nameof(model.IdCategory),
                    CreateProductMessages.CategoryNotFoundError
                ));
            }

            return !ErrorsField.Any();
        }
    }
}
