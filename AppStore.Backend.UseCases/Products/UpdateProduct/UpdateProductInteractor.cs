namespace AppStore.Backend.UseCases.Products.UpdateProduct
{
    internal class UpdateProductInteractor(
       IUpdateProductOutputPort outputPort,
       ICommandsRepository commands,
       IQueriesRepository queries,
       IModelValidatorHub<UpdateProductDto> modelValidatorHub) : IUpdateProductInputPort
    {
        public async Task Handle(UpdateProductDto productDto)
        {
            //Validamos antes que todo el DTO.
            await GuardModel.AgainstNotValid(modelValidatorHub, productDto);

            // 2) Construir el producto con los nuevos datos (dominio valida invariantes)
            var product = new Product(
                productDto.IdCategory,
                productDto.InternalCode,
                productDto.Name,
                productDto.Price,
               
                productDto.IdSupplier,
                productDto.Description
            )
            {
                IdProduct = productDto.IdProduct
            };

            // 3) Persistir cambios
            await commands.UpdateProduct(product);
            await commands.SaveChanges();
            // 4) Respuesta
            await outputPort.Handle(product);
        }
    }
}
