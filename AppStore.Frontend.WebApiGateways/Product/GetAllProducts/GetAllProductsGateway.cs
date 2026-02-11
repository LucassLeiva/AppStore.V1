namespace AppStore.Frontend.WebApiGateways.Product.GetAllProducts
{
    //internal class GetAllProductsGateway(HttpClient client)
    //    : IGetAllProductsGateway
    //{
    //    public async Task<IEnumerable<ProductItemDto>> GetAllAsync(bool includeInactive)
    //    {
    //        var url = $"{Endpoints.GetAllProducts}?includeInactive={includeInactive}";

    //        var response = await client.GetAsync(url);

    //        if (response.IsSuccessStatusCode)
    //        {
    //            return await response.Content.ReadFromJsonAsync<IEnumerable<ProductItemDto>>()
    //                   ?? [];
    //        }
    //        else
    //        {
    //            throw new HttpRequestException(
    //                await response.Content.ReadAsStringAsync());
    //        }
    //    }
    //}
    internal class GetAllProductsGateway(HttpClient client)
        : IGetAllProductsGateway
    {
        public async Task<IEnumerable<ProductItemDto>> GetAllAsync(bool includeInactive)
        {
            var url = $"{Endpoints.GetAllProducts}?includeInactive={includeInactive}";

            return (await client.GetFromJsonAsync<IEnumerable<ProductItemDto>>(url))
                   ?? [];
        }
    }
}
