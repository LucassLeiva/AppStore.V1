namespace AppStore.Backend.UseCases.Stocks.UpdateStock
{
    internal class UpdateStockInteractor(
         ICommandsRepository commands,
         IQueriesRepository queries,
         IUpdateStockOutputPort outputPort,
         IModelValidatorHub<UpdateStockDto> modelValidatorHub)
         : IUpdateStockInputPort
    {
        public async Task Handle(UpdateStockDto updateDto)
        {
            await GuardModel.AgainstNotValid(modelValidatorHub, updateDto);
            int stockId = await queries.GetStockIdByProductId(updateDto.IdProduct);

            await commands.UpdateStockAmount(stockId, updateDto.Amount);

            await outputPort.Handle(updateDto.IdProduct);
        }
    }
}
