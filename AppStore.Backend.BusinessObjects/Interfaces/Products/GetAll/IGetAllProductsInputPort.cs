using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Products.GetAll
{
    public interface IGetAllProductsInputPort
    {
        Task Handle(bool includeInactive);
    }
}
