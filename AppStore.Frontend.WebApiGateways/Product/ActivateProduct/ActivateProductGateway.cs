namespace AppStore.Frontend.WebApiGateways.Product.ActivateProduct
{
    internal class ActivateProductGateway(HttpClient client) : IActivateProductGateway
    {
        public async Task<int> ActivateAsync(int idProduct)
        {
            var url = $"{Endpoints.ActivateProduct}?idProduct={idProduct}";

            var response = await client.PutAsync(url, content: null);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<int>();
        }
    }
}
