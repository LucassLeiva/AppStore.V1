using AppStore.Entities.DTOs.Products.GetProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Frontend.BusinessObjects.Interfaces.Product.GetProductById
{
    public interface IGetProductByIdGateway
    {
        Task<ProductDetailsDto> GetByIdAsync(int idProduct);
    }
}
