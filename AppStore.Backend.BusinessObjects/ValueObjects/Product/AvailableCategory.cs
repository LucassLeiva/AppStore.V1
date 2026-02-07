using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.ValueObjects.Product
{

    public class AvailableCategory(int idCategory, string name)
    {
        public int IdCategory => idCategory;
        public string Name => name;
    }

}
