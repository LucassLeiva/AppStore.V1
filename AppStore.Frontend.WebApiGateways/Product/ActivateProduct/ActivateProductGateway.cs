namespace AppStore.Frontend.WebApiGateways.Product.ActivateProduct
{
    internal class ActivateProductGateway(HttpClient client) : IActivateProductGateway
    {
        public async Task<int> ActivateAsync(int idProduct)
        {
            var response = await client.PutAsync($"{Endpoints.ActivateProduct}?idProduct={idProduct}",content: null);

            return await response.Content.ReadFromJsonAsync<int>();
        }
    }
}
