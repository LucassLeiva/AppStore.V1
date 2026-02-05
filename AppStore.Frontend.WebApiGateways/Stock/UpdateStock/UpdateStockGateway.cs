namespace AppStore.Frontend.WebApiGateways.Stock.UpdateStock
{
    internal class UpdateStockGateway(HttpClient client) : IUpdateStockGateway
    {
        public async Task UpdateAsync(UpdateStockDto dto)
        {
            var response = await client.PutAsJsonAsync(Endpoints.UpdateStock, dto);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(
                    await response.Content.ReadAsStringAsync());
        }
    }
}
