using AppStore.Entities.DTOs.Products.DeleteProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Products.DeleteProduct
{
    public interface IDeleteProductInputPort
    {
        Task Handle(DeleteProductDto dto);
    }
}
