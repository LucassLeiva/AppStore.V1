using AppStore.Backend.BusinessObjects.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Categories.CreateCategory
{
    public interface ICreateCategoryOutputPort
    {
        int IdCategory { get; }
        Task Handle(Category addedCategory);
    }
}
