namespace AppStore.Backend.BusinessObjects.Interfaces.Products.ActivateProduct
{
    public interface IActivateProductInputPort
    {
        Task Handle(ActivateProductDto dto);
    }
}
