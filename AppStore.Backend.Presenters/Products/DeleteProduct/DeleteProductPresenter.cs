using AppStore.Backend.BusinessObjects.Interfaces.Products.DeleteProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.Presenters.Products.DeleteProduct
{
    internal class DeleteProductPresenter : IDeleteProductOutputPort
    {
        public int IdProduct { get; private set; }

        public Task Handle(int idProduct)
        {
            IdProduct = idProduct;
            return Task.CompletedTask;
        }
    }
}
