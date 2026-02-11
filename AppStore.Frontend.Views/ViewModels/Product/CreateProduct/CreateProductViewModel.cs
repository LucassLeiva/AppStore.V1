namespace AppStore.Frontend.Views.ViewModels.Product.CreateProduct
{
    public class CreateProductViewModel(
       ICreateProductGateway gateway,
       IModelValidatorHub<CreateProductViewModel> validator,
       IGetAllCategoriesGateway categoriesGateway,
       IGetAllSuppliersGateway suppliersGateway)
    {
        #region Propiedades relacionadas a CreateProductDto
        public int IdCategory { get; set; }
        public string InternalCode { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short StockInicial { get; set; }
        public string? Description { get; set; }
        public int IdSupplier { get; set; }
        public int State { get; set; } = 1;
        #endregion

        #region Lista para Categorias y Proveedores
        public IEnumerable<CategoryItemDto> Categories { get; private set; } = [];
        public IEnumerable<SupplierItemDto> Suppliers { get; private set; } = [];
        #endregion
        public string InformationMessage { get; private set; }

        public IModelValidatorHub<CreateProductViewModel> Validator => validator;
        public ModelValidator<CreateProductViewModel> ModelValidatorComponentReference{ get; set; }
        public async Task LoadCombos()
        {
            //false para que elija solo los activos

            Categories = await categoriesGateway.GetAllAsync(false);
            Suppliers = await suppliersGateway.GetAllAsync(false);

            // .First().IdCategory o IdSupplier: seteamos el primero de la categoria de forma default.
            if (Categories.Any() && IdCategory == 0)
                IdCategory = Categories.First().IdCategory;

            if (Suppliers.Any() && IdSupplier == 0)
                IdSupplier = Suppliers.First().IdSupplier;
        }

        public async Task Send()
        {
            InformationMessage = "";
            try
            {

                var productId = await gateway.CreateProductAsync((CreateProductDto)this);
                InformationMessage = string.Format(CreateProductMessages.CreatedProductTemplate, productId);

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

        public static explicit operator CreateProductDto(CreateProductViewModel model) =>
            new CreateProductDto(
                model.IdCategory,
                model.InternalCode,
                model.Name,
                model.Price,
                model.StockInicial,
                model.Description,
                model.IdSupplier

            );
    }
}
