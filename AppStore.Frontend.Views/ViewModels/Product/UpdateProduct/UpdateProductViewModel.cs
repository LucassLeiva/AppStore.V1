namespace AppStore.Frontend.Views.ViewModels.Product.UpdateProduct
{
    public class UpdateProductViewModel(IUpdateProductGateway productGateway,
                                        IUpdateStockGateway stockGateway, 
                                        IGetAllCategoriesGateway categoriesGateway,
                                         IGetAllSuppliersGateway suppliersGateway,
                                        IGetProductByIdGateway getByIdGateway,
                                        
                                        IModelValidatorHub<UpdateProductViewModel> validator)
    {
        #region --Propiedades relacionadas a UpdateProductDto--
        // Los atributos que vamos a editar
        public int IdProduct { get; private set; }
        public string InternalCode { get; set; } = "";
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string? Description { get; set; }

        // IDS necesarios para guardar
        public int IdCategory { get; set; }
        public int IdSupplier { get; set; }
        #endregion
        #region --Atributos para manipular Stock--
        public int StockAmount { get; set; }
        private int _originalStockAmount;
        #endregion
        #region --"Listas" para los dropdowns--
        public IEnumerable<CategoryItemDto> Categories { get; private set; } = [];
        public IEnumerable<SupplierItemDto> Suppliers { get; private set; } = [];
        #endregion
        #region --Propiedades relacionadas a la Validacion--
        public string InformationMessage { get; private set; } = "";
        public IModelValidatorHub<UpdateProductViewModel> Validator => validator;
        public ModelValidator<UpdateProductViewModel>ModelValidatorComponentReference { get; set; }
        #endregion

        public async Task Load(int idProduct)
        {
            InformationMessage = "";

            Categories = await categoriesGateway.GetAllAsync(false);
            Suppliers = await suppliersGateway.GetAllAsync(false);

            var p = await getByIdGateway.GetByIdAsync(idProduct);

            IdProduct = p.IdProduct;
            InternalCode = p.InternalCode;
            Name = p.Name;
            Price = p.Price;
            Description = p.Description;
            IdCategory = p.IdCategory;
            IdSupplier = p.IdSupplier;
            StockAmount = p.StockAmount;
            _originalStockAmount = p.StockAmount;
        }


        public async Task Save()
        {
            InformationMessage = "";

            try
            {
                await productGateway.UpdateAsync((UpdateProductDto)this);

                if (StockAmount != _originalStockAmount)
                {
                    await stockGateway.UpdateAsync(new UpdateStockDto(IdProduct, StockAmount));
                    _originalStockAmount = StockAmount;
                }

                InformationMessage = string.Format(
                    UpdateProductMessages.UpdatedProductTemplate, IdProduct);
            }
            catch (HttpRequestException ex)
            {
                if (ex.Data.Contains("Errors"))
                {
                    var errors = ex.Data["Errors"] as IEnumerable<ValidationError>;

                    if (errors is not null)
                    {
                        ModelValidatorComponentReference.AddErrors(errors);
                        return;
                    }
                }

                // Si no vino lista de errores, mostramos mensaje genérico
                InformationMessage = ex.Message;
            }

        }

        public static explicit operator UpdateProductDto(UpdateProductViewModel model) =>
            new UpdateProductDto(
                model.IdProduct,
                model.IdCategory,
                model.InternalCode,
                model.Name,
                model.Price,
                model.Description,
                model.IdSupplier
            );
    }
}

