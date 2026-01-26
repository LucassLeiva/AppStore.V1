using AppStore.Backend.BusinessObjects.Interfaces.Stocks.UpdateStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.Presenters.Stock.UpdateStock
{
    internal class UpdateStockPresenter : IUpdateStockOutputPort
    {
        public int IdProduct { get; private set; }

        public Task Handle(int idProduct)
        {
            IdProduct = idProduct;
            return Task.CompletedTask;
        }
    }
}
