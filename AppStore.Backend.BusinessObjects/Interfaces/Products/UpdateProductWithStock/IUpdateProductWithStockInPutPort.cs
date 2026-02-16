using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Products.UpdateProductWithStock
{
    public interface IUpdateProductWithStockInputPort
    {
        Task Handle(UpdateProductWithStockDto updateProductWithStockDto);
    }
}
