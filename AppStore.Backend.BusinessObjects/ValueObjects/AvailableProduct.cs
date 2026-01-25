namespace AppStore.Backend.BusinessObjects.ValueObjects
{
    public class AvailableProduct(int idProduct, string internalCode)
    {
        public int IdProduct => idProduct;
        public string InternalCode => internalCode;
    }
}
