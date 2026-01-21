using AppStore.Backend.BusinessObjects.Interfaces.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.Presenters.CreateProduct
{
    internal class CreateProductPresenter : ICreateProductOutputPort
    {
        public int IdProduct { get; private set; }

        public Task Handle(Product addedProduct)
        {
            IdProduct = addedProduct.IdProduct;
            return Task.CompletedTask;
        }
    }

}
