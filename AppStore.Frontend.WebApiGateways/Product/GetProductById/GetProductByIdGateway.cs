using AppStore.Entities.DTOs.Products.GetProducts;
using AppStore.Frontend.BusinessObjects.Interfaces.Product.GetProductById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Frontend.WebApiGateways.Product.GetProductById
{
    internal class GetProductByIdGateway(HttpClient client): IGetProductByIdGateway
    {
        public async Task<ProductDetailsDto> GetByIdAsync(int idProduct)
        {
            var url = $"{Endpoints.GetProductById}?idProduct={idProduct}";

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(await response.Content.ReadAsStringAsync());

            return (await response.Content.ReadFromJsonAsync<ProductDetailsDto>())!;
        }
    }
}
