namespace AppStore.Backend.UseCases.Stocks.UpdateStock
{
    internal class UpdateStockInteractor(
         ICommandsRepository commands,
         IQueriesRepository queries,
         IUpdateStockOutputPort outputPort)
         : IUpdateStockInputPort
    {
        public async Task Handle(UpdateStockDto dto)
        {

            int stockId = await queries.GetStockIdByProductId(dto.IdProduct);

            await commands.UpdateStockAmount(stockId, dto.Amount);

            await outputPort.Handle(dto.IdProduct);
        }
    }
}
