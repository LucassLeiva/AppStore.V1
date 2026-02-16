namespace AppStore.Frontend.WebApiGateways.Product.UpdateProductWithStock
{
    internal class UpdateProductWithStockGateway(HttpClient client)
        : IUpdateProductWithStockGateway
    {
        public async Task<int> UpdateProductWithStockAsync(
            UpdateProductWithStockDto dto)
        {
            var response = await client.PutAsJsonAsync(
                Endpoints.UpdateProductWithStock,
                dto
            );

            return await response.Content.ReadFromJsonAsync<int>();
        }
    }
}
