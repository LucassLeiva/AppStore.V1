using AppStore.Entities.DTOs.Products.GetProducts;

namespace AppStore.Frontend.WebApiGateways.Product.UpdateProduct
{
    internal class UpdateProductGateway(HttpClient client) : IUpdateProductGateway
    {

        public async Task<ProductDetailsDto> GetByIdAsync(int idProduct)
        {
            var url = $"{Endpoints.GetProductById}?idProduct={idProduct}"; 
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return (await response.Content.ReadFromJsonAsync<ProductDetailsDto>())!;

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }

        public async Task UpdateAsync(UpdateProductDto dto)
        {
            var response = await client.PutAsJsonAsync(Endpoints.UpdateProduct, dto);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(await response.Content.ReadAsStringAsync());
            
        }
    }
}
