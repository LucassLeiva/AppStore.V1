using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.CreateProduct
{
    public interface ICreateProductOutputPort
    {
        int IdProduct { get; }
        Task Handle(Product addedProduct);
    }
}
