using AppStore.Entities.DTOs.Products.UpdateProductWithStock;
using AppStore.Frontend.BusinessObjects.Interfaces.Product.UpdateProductWithStock;
using AppStore.Frontend.Views.Models.Product.UpdateProduct;
using AppStore.Frontend.Views.Utilities;

namespace AppStore.Frontend.Views.ViewModels.Product.UpdateProduct
{
    public class UpdateProductViewModel(IUpdateProductGateway productGateway,
                                        IUpdateStockGateway stockGateway,
                                        IUpdateProductWithStockGateway updateProductWithStockGateway,
                                        IGetAllCategoriesGateway categoriesGateway,
                                         IGetAllSuppliersGateway suppliersGateway,
                                        IGetProductByIdGateway getByIdGateway,      
                                        IModelValidatorHub<UpdateProductViewModel> validator)
    {
        #region Metodos para Normalizar Inputs
        private void NormalizeTextFields()
        {
            Model.InternalCode = TextNormalizer.UpperInvariant(Model.InternalCode);
            Model.Name = TextNormalizer.CapitalizeWords(Model.Name);
            Model.Description = TextNormalizer.CapitalizeFirstLetter(Model.Description);
        }
        private static string? NormalizeOptional(string? s)
        {
            if (s is null) return null;
            s = s.Trim();
            return s.Length == 0 ? null : s;
        }
        //Normalizar en OnBlour en Input
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
        #endregion
        #region Declaracion de Variables
        public UpdateProductModel Model { get; private set; } = new();
        private UpdateProductSnapshot? _original;
        //Utilizamos un record porque necesitamos que sea ininmutable la varible para comparar si cambio o no los datos del producto desde la UI.
        private record UpdateProductSnapshot(
           int IdCategory,
           string InternalCode,
           string Name,
           decimal Price,
           string? Description,
           int IdSupplier,
           int StockAmount
       );
        #endregion
        #region --Propiedades relacionadas a la Validacion--
        public string InformationMessage { get; private set; } = "";
        public IModelValidatorHub<UpdateProductViewModel> Validator => validator;
        public ModelValidator<UpdateProductViewModel>ModelValidatorComponentReference { get; set; }
        #endregion

        public async Task Load(int idProduct)
        {
            InformationMessage = "";

            Model.Categories = await categoriesGateway.GetAllAsync(false);
            Model.Suppliers = await suppliersGateway.GetAllAsync(false);

            var p = await getByIdGateway.GetByIdAsync(idProduct);

            Model.IdProduct = p.IdProduct;
            Model.InternalCode = p.InternalCode;
            Model.Name = p.Name;
            Model.Price = p.Price;
            Model.Description = p.Description;
            Model.IdCategory = p.IdCategory;
            Model.IdSupplier = p.IdSupplier;
            Model.StockAmount = p.StockAmount;

            // Guardamos snapshot original
            _original = new UpdateProductSnapshot(
                Model.IdCategory,
                Model.InternalCode,
                Model.Name,
                Model.Price,
                NormalizeOptional(Model.Description),
                Model.IdSupplier,
                Model.StockAmount
            );
        }

        private bool ProductChanged()
        {
            if (_original is null) return true;

            return
                Model.IdCategory != _original.IdCategory ||
                Model.IdSupplier != _original.IdSupplier ||
                Model.Price != _original.Price ||
                !string.Equals(Model.InternalCode, _original.InternalCode, StringComparison.Ordinal) ||
                !string.Equals(Model.Name, _original.Name, StringComparison.Ordinal) ||
                !string.Equals(NormalizeOptional(Model.Description), _original.Description, StringComparison.Ordinal);
        }

        private bool StockChanged()
        {
            if (_original is null) return true;
            return Model.StockAmount != _original.StockAmount;
        }

        public async Task Save()
        {
            InformationMessage = "";
            NormalizeTextFields();

            try
            {
                var productChanged = ProductChanged();
                var stockChanged = StockChanged();
                await productGateway.UpdateAsync((UpdateProductDto)this);

                if (productChanged && stockChanged)
                {
                    await updateProductWithStockGateway.UpdateProductWithStockAsync(
                        (UpdateProductWithStockDto)this);

                }
                else if (productChanged)
                {
                    // Caso 2: Solo producto
                    await productGateway.UpdateAsync((UpdateProductDto)this);
                }
                else if (stockChanged)
                {
                    // Caso 3: Solo stock
                    await stockGateway.UpdateStockAsync(
                        new UpdateStockDto(Model.IdProduct, Model.StockAmount)
                    );
                }
                else
                {
                    InformationMessage = "No hay cambios para guardar.";
                    return;
                }

                _original = new UpdateProductSnapshot(
                    Model.IdCategory,
                    Model.InternalCode,
                    Model.Name,
                    Model.Price,
                    NormalizeOptional(Model.Description),
                    Model.IdSupplier,
                    Model.StockAmount
                );

                // Mensaje (usa el nombre ingresado)
                InformationMessage = $"Producto \"{Model.Name}\" actualizado correctamente.";
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

        public static explicit operator UpdateProductDto(UpdateProductViewModel vm) =>
            new UpdateProductDto(
                vm.Model.IdProduct,
                vm.Model.IdCategory,
                vm.Model.InternalCode,
                vm.Model.Name,
                vm.Model.Price,
                NormalizeOptional(vm.Model.Description),
                vm.Model.IdSupplier
            );
        public static explicit operator UpdateProductWithStockDto(UpdateProductViewModel vm) =>
            new UpdateProductWithStockDto(
                vm.Model.IdProduct,
                vm.Model.IdCategory,
                vm.Model.InternalCode,
                vm.Model.Name,
                vm.Model.Price,
                NormalizeOptional(vm.Model.Description),
                vm.Model.IdSupplier,
                vm.Model.StockAmount
            );

    }
}

