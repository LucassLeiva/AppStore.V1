using AppStore.Backend.BusinessObjects.Interfaces.Products.UpdateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.Presenters.Products.UpdateProduct
{
    internal class UpdateProductPresenter : IUpdateProductOutputPort
    {
        public int IdProduct { get; private set; }

        public Task Handle(Product updatedProduct)
        {
            IdProduct = updatedProduct.IdProduct;
            return Task.CompletedTask;
        }
    }
}
