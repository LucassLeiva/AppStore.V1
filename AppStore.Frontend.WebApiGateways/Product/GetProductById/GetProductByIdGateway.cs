namespace AppStore.Frontend.WebApiGateways.Product.GetProductById
{
    internal class GetProductByIdGateway(HttpClient client)
        : IGetProductByIdGateway
    {
        public async Task<ProductDetailsDto> GetByIdAsync(int idProduct)
        {
            var url = $"{Endpoints.GetProductById}?idProduct={idProduct}";

            return await client.GetFromJsonAsync<ProductDetailsDto>(url);
        }
    }
}
