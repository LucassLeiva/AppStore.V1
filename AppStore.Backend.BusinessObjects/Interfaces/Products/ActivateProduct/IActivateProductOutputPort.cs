using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Products.ActivateProduct
{
    public interface IActivateProductOutputPort
    {
        int IdProduct { get; }
        Task Handle(int idProduct);
    }
}
