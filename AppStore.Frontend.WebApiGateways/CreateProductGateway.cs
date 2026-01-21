namespace AppStore.Frontend.WebApiGateways
{
    internal class CreateProductGateway(HttpClient client)
         : ICreateProductGateway
    {
        public async Task<int> CreateProductAsync(CreateProductDto product)
        {
            int productId = 0;

            var response = await client.PostAsJsonAsync(Endpoints.CreateProduct, product);

            if (response.IsSuccessStatusCode)
            {
                productId = await response.Content.ReadFromJsonAsync<int>();
            }

            return productId;
        }
    }
}
