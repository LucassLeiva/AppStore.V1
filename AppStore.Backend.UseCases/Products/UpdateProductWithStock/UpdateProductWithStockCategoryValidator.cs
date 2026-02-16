namespace AppStore.Backend.UseCases.Products.UpdateProduct
{
    
        internal class UpdateProductWithStockCategoryValidator(
            IQueriesRepository repository) : IModelValidator<UpdateProductWithStockDto>
        {
            readonly List<ValidationError> ErrorsField = [];
            public IEnumerable<ValidationError> Errors => ErrorsField;

            public ValidationConstraint Constraint =>
                ValidationConstraint.ValidateIfThereAreNoPreviousErrors;

            public async Task<bool> Validate(UpdateProductWithStockDto model)
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
