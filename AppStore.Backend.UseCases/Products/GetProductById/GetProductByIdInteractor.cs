namespace AppStore.Backend.UseCases.Products.GetProductById
{
    internal class GetProductByIdInteractor(
    IQueriesRepository repository,
    IGetProductByIdOutputPort outputPort)
    : IGetProductByIdInputPort
    {
        public async Task Handle(int idProduct)
        {
            var product = await repository.GetProductById(idProduct);
            await outputPort.Handle(product);
        }
    }

}
