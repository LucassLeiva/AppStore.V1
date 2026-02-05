namespace AppStore.Backend.UseCases.Products.ActivateProduct
{
    internal class ActivateProductInteractor(
        ICommandsRepository commands,
        IActivateProductOutputPort outputPort)
        : IActivateProductInputPort
    {
        public async Task Handle(ActivateProductDto dto)
        {
            await commands.UpdateProductState(dto.IdProduct, 1);
            await outputPort.Handle(dto.IdProduct);
        }
    }
}
