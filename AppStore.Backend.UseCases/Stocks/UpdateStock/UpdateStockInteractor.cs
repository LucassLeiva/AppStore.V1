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
            // 1) obtener el stock asociado al producto
            int stockId = await queries.GetStockIdByProductId(dto.IdProduct);

            // 2) actualizar cantidad
            await commands.UpdateStockAmount(stockId, dto.Amount);

            // 3) regla de negocio: activar / desactivar producto
            if (dto.Amount > 0)
            {
                await commands.UpdateProductState(dto.IdProduct, 1); // activo
            }
            else
            {
                await commands.UpdateProductState(dto.IdProduct, 0); // inactivo
            }
            // 4) salida
            await outputPort.Handle(dto.IdProduct);
        }
    }
}
