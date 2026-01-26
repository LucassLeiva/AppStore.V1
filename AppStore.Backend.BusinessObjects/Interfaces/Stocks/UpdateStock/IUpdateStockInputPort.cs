using AppStore.Entities.DTOs.Stock.UpdateStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Stocks.UpdateStock
{
    public interface IUpdateStockInputPort
    {
        Task Handle(UpdateStockDto dto);
    }
}
