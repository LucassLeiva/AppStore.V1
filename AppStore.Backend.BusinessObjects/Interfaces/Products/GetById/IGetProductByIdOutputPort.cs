using AppStore.Entities.DTOs.Products.GetProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Products.GetById
{
    public interface IGetProductByIdOutputPort
    {
        ProductDetailsDto? Product { get; }
        Task Handle(ProductDetailsDto? product);
    }
}
