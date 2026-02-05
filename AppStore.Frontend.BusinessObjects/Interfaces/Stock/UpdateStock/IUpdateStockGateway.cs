using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Frontend.BusinessObjects.Interfaces.Stock.UpdateStock
{
    public interface IUpdateStockGateway
    {
        Task UpdateAsync(UpdateStockDto dto);
    }
}
