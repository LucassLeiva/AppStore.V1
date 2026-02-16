namespace AppStore.Backend.UseCases.Products.UpdateProduct
{
    internal class UpdateProductWithStockInternalCodeValidator(
        IQueriesRepository repository) : IModelValidator<UpdateProductWithStockDto>
    {
        readonly List<ValidationError> ErrorsField = [];
        public IEnumerable<ValidationError> Errors => ErrorsField;

        public ValidationConstraint Constraint =>
            ValidationConstraint.ValidateIfThereAreNoPreviousErrors;

        public async Task<bool> Validate(UpdateProductWithStockDto model)
        {
            // Obtenemos todos los productos disponibles
            var products = await repository.GetAvailableProducts();

            bool duplicated = 
                products.Any(p =>
                p.IdProduct != model.IdProduct && // ✅ EXCLUIR EL MISMO PRODUCTO
                p.InternalCode.Equals(model.InternalCode, StringComparison.OrdinalIgnoreCase)
            );

            if (duplicated)
            {
                ErrorsField.Add(new ValidationError(
                    nameof(model.InternalCode),
                    UpdateProductMessages.ProductInternalCodeAlreadyExists
                ));
            }

            return !ErrorsField.Any();
        }
    }
}
