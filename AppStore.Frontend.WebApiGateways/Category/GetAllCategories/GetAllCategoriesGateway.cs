namespace AppStore.Frontend.WebApiGateways.Category.GetAllCategories
{
    internal class GetAllCategoriesGateway(HttpClient client) : IGetAllCategoriesGateway
    {
        public async Task<IEnumerable<CategoryItemDto>> GetAllAsync(bool includeInactive)
        {
            var url = $"{Endpoints.GetAllCategories}?includeInactive={includeInactive}";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<CategoryItemDto>>()
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
