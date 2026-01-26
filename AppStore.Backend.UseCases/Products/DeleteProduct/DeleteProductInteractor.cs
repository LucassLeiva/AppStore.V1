namespace AppStore.Backend.UseCases.Products.DeleteProduct
{
    internal class DeleteProductInteractor(
        IDeleteProductOutputPort outputPort,
        ICommandsRepository repository) : IDeleteProductInputPort
    {
        public async Task Handle(DeleteProductDto dto)
        {
            int id = await repository.DeleteProduct(dto.IdProduct);
            await outputPort.Handle(id);
        }
    }
}
