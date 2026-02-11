namespace AppStore.Frontend.WebApiGateways.Product.DeleteProduct
{
    internal class DeleteProductGateway(HttpClient client) : IDeleteProductGateway
    {
        public async Task<int> DeleteAsync(int idProduct)
        {
            var response = await client.DeleteAsync( $"{Endpoints.DeleteProduct}?idProduct={idProduct}");
            return await response.Content.ReadFromJsonAsync<int>();
        }
    }
}
