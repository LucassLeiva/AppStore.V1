namespace AppStore.Backend.UseCases.Products.CreateProduct
{
    internal class CreateProductSupplierValidator(
        IQueriesRepository repository) : IModelValidator<CreateProductDto>
    {
        readonly List<ValidationError> ErrorsField = [];
        public IEnumerable<ValidationError> Errors => ErrorsField;

        public ValidationConstraint Constraint =>
            ValidationConstraint.ValidateIfThereAreNoPreviousErrors;

        public async Task<bool> Validate(CreateProductDto model)
        {
            var suppliers = await repository.GetAvailableSuppliers();

            bool exists = suppliers.Any(s => s.IdSupplier == model.IdSupplier);
            if (!exists)
            {
                ErrorsField.Add(new ValidationError(
                    nameof(model.IdSupplier),
                    CreateProductMessages.SupplierNotFoundError
                ));
            }

            return !ErrorsField.Any();
        }
    }
}
