namespace AppStore.Backend.UseCases.Products.UpdateProduct
{
    internal class UpdateProductWithStockSupplierValidator(
        IQueriesRepository repository) : IModelValidator<UpdateProductWithStockDto>
    {
        readonly List<ValidationError> ErrorsField = [];
        public IEnumerable<ValidationError> Errors => ErrorsField;

        public ValidationConstraint Constraint =>
            ValidationConstraint.ValidateIfThereAreNoPreviousErrors;

        public async Task<bool> Validate(UpdateProductWithStockDto model)
        {
            var suppliers = await repository.GetAvailableSuppliers();

            bool exists = suppliers.Any(s => s.IdSupplier == model.IdSupplier);
            if (!exists)
            {
                ErrorsField.Add(new ValidationError(
                    nameof(model.IdSupplier),
                    UpdateProductMessages.SupplierNotFoundError
                ));
            }

            return !ErrorsField.Any();
        }
    }
}
