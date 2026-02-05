using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Frontend.BusinessObjects.Interfaces.Product.DeleteProduct
{
    public interface IDeleteProductGateway
    {
        Task<int> DeleteAsync(int idProduct);
    }
}
