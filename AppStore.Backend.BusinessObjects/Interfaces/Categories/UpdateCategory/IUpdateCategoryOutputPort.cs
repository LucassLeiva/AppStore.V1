using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Categories.UpdateCategory
{
    public interface IUpdateCategoryOutputPort
    {
        int IdCategory { get; }
        Task Handle(Category updatedCategory);
    }

}
