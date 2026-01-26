using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Products.DeleteProduct
{
    public interface IDeleteProductOutputPort
    {
        int IdProduct { get; }
        Task Handle(int idProduct);
    }
}
