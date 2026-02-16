namespace AppStore.Frontend.WebApiGateways.Product.UpdateProduct
{
    internal class UpdateProductGateway(HttpClient client) : IUpdateProductGateway
    {
        public async Task UpdateAsync(UpdateProductDto updateProductdto)
        {
            var response = await client.PutAsJsonAsync(Endpoints.UpdateProduct, updateProductdto);
            
        }
    }
}
