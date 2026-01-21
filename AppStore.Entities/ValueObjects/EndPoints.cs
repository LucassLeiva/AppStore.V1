using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Entities.ValueObjects
{

    //El uso de endpoints previene los string magicos. Un string mágico es un texto escrito “a mano” que no tiene consistencia,
    //si se cambia en un lado hay que cambiarlo manualmente en todo el codigo pudiendo producir bugs.
    public class Endpoints
    {
        public const string CreateProduct = $"/{nameof(CreateProduct)}";

        public const string CreateCategory = $"/{nameof(CreateCategory)}";

        public const string CreateSupplier = $"/{nameof(CreateSupplier)}";
    }
}
