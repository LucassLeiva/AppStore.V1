using AppStore.Validation.Entities.Interfaces;

namespace AppStore.Backend.UseCases.Products.DeleteProduct
{
    internal class DeleteProductInteractor(
        IDeleteProductOutputPort outputPort,
        ICommandsRepository repository,
        IModelValidatorHub<DeleteProductDto> modelValidatorHub) : IDeleteProductInputPort
    {
        public async Task Handle(DeleteProductDto deleteProductDto)
        {
            await GuardModel.AgainstNotValid(modelValidatorHub, deleteProductDto);
            int id = await repository.DeleteProduct(deleteProductDto.IdProduct);
            await outputPort.Handle(id);
        }
    }
}
