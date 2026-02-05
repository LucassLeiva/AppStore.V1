namespace AppStore.Frontend.WebApiGateways.Product.DeleteProduct
{
    internal class DeleteProductGateway(HttpClient client)
         : IDeleteProductGateway
    {
        public async Task<int> DeleteAsync(int idProduct)
        {
            
            var url = $"{Endpoints.DeleteProduct}?idProduct={idProduct}";

            var response = await client.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(
                    await response.Content.ReadAsStringAsync());

            // El controller devuelve el id del producto que se borro
            return await response.Content.ReadFromJsonAsync<int>();
        }
    }
}
