namespace AppStore.Backend.UseCases.Products.ActivateProduct
{
    internal class ActivateProductInteractor(
        ICommandsRepository commands,
        IActivateProductOutputPort outputPort,
        IModelValidatorHub<ActivateProductDto> modelValidatorHub)
        : IActivateProductInputPort
    {
        public async Task Handle(ActivateProductDto activateProductDto)
        {
            await GuardModel.AgainstNotValid(modelValidatorHub, activateProductDto);
            await commands.UpdateProductState(activateProductDto.IdProduct, 1);
            await outputPort.Handle(activateProductDto.IdProduct);
        }
    }
}
