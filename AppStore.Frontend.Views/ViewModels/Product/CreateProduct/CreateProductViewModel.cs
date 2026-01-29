namespace AppStore.Frontend.Views.ViewModels.Product.CreateProduct
{
    public class CreateProductViewModel(ICreateProductGateway gateway, IModelValidatorHub<CreateProductViewModel> validator)
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

        public string InformationMessage { get; private set; }

        public IModelValidatorHub<CreateProductViewModel> Validator => validator;

        public async Task Send()
        {
            InformationMessage = "";

            var productId = await gateway.CreateProductAsync((CreateProductDto)this);

           
            InformationMessage = string.Format(
                CreateProductMessages.CreatedProductTemplate, productId);
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
