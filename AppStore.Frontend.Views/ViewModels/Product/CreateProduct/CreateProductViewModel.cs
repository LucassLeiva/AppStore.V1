using AppStore.Frontend.Views.Utilities;

namespace AppStore.Frontend.Views.ViewModels.Product.CreateProduct
{
    public class CreateProductViewModel(
       ICreateProductGateway gateway,
       IModelValidatorHub<CreateProductViewModel> validator,
       IGetAllCategoriesGateway categoriesGateway,
       IGetAllSuppliersGateway suppliersGateway)
    {
        #region Declaracion de Variables
        public CreateProductModel Model { get; private set; } = new();
        public IEnumerable<CategoryItemDto> Categories { get; private set; } = [];
        public IEnumerable<SupplierItemDto> Suppliers { get; private set; } = [];
        public string InformationMessage { get; private set; }
        #endregion
        #region Validacion
        public IModelValidatorHub<CreateProductViewModel> Validator => validator;
        public ModelValidator<CreateProductViewModel> ModelValidatorComponentReference { get; set; }
        #endregion
        #region Metodos para Normalizar Inputs
        private void NormalizeTextFields()
        {
            Model.InternalCode = TextNormalizer.UpperInvariant(Model.InternalCode);
            Model.Name = TextNormalizer.CapitalizeWords(Model.Name);
            Model.Description = TextNormalizer.CapitalizeFirstLetter(Model.Description);
        }
        public void NormalizeInternalCode()
        {
            Model.InternalCode = TextNormalizer.UpperInvariant(Model.InternalCode);
        }
        public void NormalizeName()
        {
            Model.Name = TextNormalizer.CapitalizeWords(Model.Name);
        }
        public void NormalizeDescription()
        {
            Model.Description = TextNormalizer.CapitalizeFirstLetter(Model.Description);

        }
        private static string? NormalizeOptional(string? s)
        {
            if (s is null) return null;
            s = s.Trim();
            return s.Length == 0 ? null : s;
        }
        #endregion


        public async Task LoadCombos()
        {
            InformationMessage = "";
            Model = new CreateProductModel();

            //false para que elija solo los activos
            Categories = await categoriesGateway.GetAllAsync(false);
            Suppliers = await suppliersGateway.GetAllAsync(false);

            // .First().IdCategory o IdSupplier: seteamos el primero de la categoria de forma default.
            if (Categories.Any() && Model.IdCategory == 0)
                Model.IdCategory = Categories.First().IdCategory;

            if (Suppliers.Any() && Model.IdSupplier == 0)
                Model.IdSupplier = Suppliers.First().IdSupplier;
        }

        public async Task Send()
        {
            InformationMessage = "";


            //Normalizamos el texto antes de guardar.
            NormalizeTextFields();
            try
            {
                var productId = await gateway.CreateProductAsync((CreateProductDto)this);
                InformationMessage = string.Format(CreateProductMessages.CreatedProductTemplate, productId, Model.Name);

                Model = new CreateProductModel();              
            }
            catch (HttpRequestException ex) 
            {
                if (ex.Data.Contains("Errors"))
                {
                    IEnumerable<ValidationError> Errors =
                    ex.Data["Errors"] as IEnumerable<ValidationError>;
                    ModelValidatorComponentReference.AddErrors(Errors);
                }
                else
                {
                    throw;
                }
            }
        }
        public static explicit operator CreateProductDto(CreateProductViewModel vm) =>
            new CreateProductDto(
                vm.Model.IdCategory,
                vm.Model.InternalCode,
                vm.Model.Name,
                vm.Model.Price,
                vm.Model.StockInicial,
                NormalizeOptional(vm.Model.Description),
                vm.Model.IdSupplier
            );
    }
}
