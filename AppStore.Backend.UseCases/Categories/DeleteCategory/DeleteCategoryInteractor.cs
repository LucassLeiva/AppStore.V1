namespace AppStore.Backend.UseCases.Categories.DeleteCategory
{
    internal class DeleteCategoryInteractor(
         IDeleteCategoryOutputPort outputPort,
         ICommandsRepository repository) : IDeleteCategoryInputPort
    {
        public async Task Handle(DeleteCategoryDto dto)
        {
            int id = await repository.DeleteCategory(dto.IdCategory);
            await outputPort.Handle(id);
        }
    }
}
