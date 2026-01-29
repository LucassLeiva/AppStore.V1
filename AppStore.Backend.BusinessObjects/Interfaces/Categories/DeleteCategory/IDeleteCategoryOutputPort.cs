using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Categories.DeleteCategory
{
    public interface IDeleteCategoryOutputPort
    {
        int IdCategory { get; }
        Task Handle(int idCategory);
    }
}
