using AppStore.Frontend.BusinessObjects.Interfaces.Product.CreateProduct;

namespace AppStore.Frontend.WebApiGateways.Product.CreateProduct
{
    internal class CreateProductGateway(HttpClient client) : ICreateProductGateway 
    {
        public async Task<int> CreateProductAsync(CreateProductDto product)
        {
            var response = await client.PostAsJsonAsync(Endpoints.CreateProduct, product);

            return await response.Content.ReadFromJsonAsync<int>();
        }
    }
}