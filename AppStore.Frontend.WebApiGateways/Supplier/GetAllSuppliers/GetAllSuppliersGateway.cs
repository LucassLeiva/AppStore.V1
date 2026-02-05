namespace AppStore.Frontend.WebApiGateways.Supplier.GetAllSuppliers
{
    internal class GetAllSuppliersGateway(HttpClient client) : IGetAllSuppliersGateway
    {
        public async Task<IEnumerable<SupplierItemDto>> GetAllAsync(bool includeInactive)
        {
            var url = $"{Endpoints.GetAllSuppliers}?includeInactive={includeInactive}";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SupplierItemDto>>()
                       ?? [];
            }
            else
            {
                throw new HttpRequestException(
                    await response.Content.ReadAsStringAsync());
            }
        }
    }
}
