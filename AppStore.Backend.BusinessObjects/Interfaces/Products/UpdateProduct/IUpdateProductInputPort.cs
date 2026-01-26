namespace AppStore.Backend.BusinessObjects.Interfaces.Products.UpdateProduct
{
    public interface IUpdateProductInputPort
    {
        Task Handle(UpdateProductDto dto);
    }
}
