namespace AppStore.Backend.UseCases.Products.GetAllProducts
{
    internal class GetAllProductsInteractor(
        IQueriesRepository repository,
        IGetAllProductsOutputPort outputPort)
        : IGetAllProductsInputPort
    {
        public async Task Handle(bool includeInactive)
        {
            var products = await repository.GetAllProducts(includeInactive);
            await outputPort.Handle(products);
        }
    }
}
