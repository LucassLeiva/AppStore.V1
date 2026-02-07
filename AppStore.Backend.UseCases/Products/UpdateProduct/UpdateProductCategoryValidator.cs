namespace AppStore.Backend.UseCases.Products.UpdateProduct
{
    
        internal class UpdateProductCategoryValidator(
            IQueriesRepository repository) : IModelValidator<UpdateProductDto>
        {
            readonly List<ValidationError> ErrorsField = [];
            public IEnumerable<ValidationError> Errors => ErrorsField;

            public ValidationConstraint Constraint =>
                ValidationConstraint.ValidateIfThereAreNoPreviousErrors;

            public async Task<bool> Validate(UpdateProductDto model)
            {
                var categories = await repository.GetAvailableCategories();

                bool exists = categories.Any(c => c.IdCategory == model.IdCategory);
                if (!exists)
                {
                    ErrorsField.Add(new ValidationError(
                        nameof(model.IdCategory),
                        UpdateProductMessages.CategoryNotFoundError
                    ));
                }

                return !ErrorsField.Any();
            }
        }
}
