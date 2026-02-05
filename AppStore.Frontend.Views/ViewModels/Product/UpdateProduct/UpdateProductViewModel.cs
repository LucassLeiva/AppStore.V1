using AppStore.Entities.DTOs.Stock.UpdateStock;
using AppStore.Frontend.BusinessObjects.Interfaces.Stock.UpdateStock;
using AppStore.Frontend.Views.Resources.Product.UpdateProduct;

namespace AppStore.Frontend.Views.ViewModels.Product.UpdateProduct
{
    public class UpdateProductViewModel(IUpdateProductGateway productGateway,
       IUpdateStockGateway stockGateway)
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

        // Para mostrar los nombres en vez de los IDS
        public string CategoryName { get; private set; } = "";
        public string SupplierName { get; private set; } = "";


        #endregion
        #region --Atributos para manipular Stock--
        public int StockAmount { get; set; }
        private int _originalStockAmount;
        #endregion

        public string InformationMessage { get; private set; } = "";
        

        public async Task Load(int idProduct)
        {
            InformationMessage = "";

            var p = await productGateway.GetByIdAsync(idProduct);

            IdProduct = p.IdProduct;
            InternalCode = p.InternalCode;
            Name = p.Name;
            Price = p.Price;
            Description = p.Description;

            IdCategory = p.IdCategory;
            CategoryName = p.CategoryName;

            IdSupplier = p.IdSupplier;
            SupplierName = p.SupplierName;

            StockAmount = p.StockAmount;
            _originalStockAmount = p.StockAmount;
        }


        public async Task Save()
        {
            InformationMessage = "";

            Console.WriteLine($"DEBUG StockAmount={StockAmount} original={_originalStockAmount}");
            //Update del Product
            await productGateway.UpdateAsync((UpdateProductDto)this);

            //Update del Stock si cambio
            if (StockAmount != _originalStockAmount)
            {
                await stockGateway.UpdateAsync(new UpdateStockDto(IdProduct, StockAmount));
                _originalStockAmount = StockAmount; // ya quedó sincronizado
            }

            InformationMessage = string.Format(
                UpdateProductMessages.UpdatedProductTemplate, IdProduct);
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

