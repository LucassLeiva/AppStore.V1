using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Categories.GetCategoriesById
{
    public interface IGetCategoryByIdInputPort
    {
        Task Handle(int idCategory);
    }
}
