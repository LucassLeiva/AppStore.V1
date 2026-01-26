using AppStore.Entities.DTOs.Products.GetProducts.AppStore.Entities.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Products.GetAll
{
    public interface IGetAllProductsOutputPort
    {
        IEnumerable<ProductItemDto> Products { get; }
        Task Handle(IEnumerable<ProductItemDto> products);
    }
}
