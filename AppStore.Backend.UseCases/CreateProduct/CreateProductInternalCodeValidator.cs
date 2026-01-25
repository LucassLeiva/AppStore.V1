using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppStore.Backend.UseCases.CreateProduct
{
    internal class CreateProductInternalCodeValidator(
        IQueriesRepository repository) : IModelValidator<CreateProductDto>
    {
        readonly List<ValidationError> ErrorsField = [];
        public IEnumerable<ValidationError> Errors => ErrorsField;

        public ValidationConstraint Constraint =>
            ValidationConstraint.ValidateIfThereAreNoPreviousErrors;

        public async Task<bool> Validate(CreateProductDto model)
        {
            // Obtenemos todos los productos disponibles
            var products = await repository.GetAvailableProducts();

            bool exists = products.Any(p =>
                p.InternalCode.Equals(
                    model.InternalCode,
                    StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                ErrorsField.Add(new ValidationError(
                    nameof(model.InternalCode),
                    CreateProductMessages.ProductInternalCodeAlreadyExists
                ));
            }

            return !ErrorsField.Any();
        }
    }
}

