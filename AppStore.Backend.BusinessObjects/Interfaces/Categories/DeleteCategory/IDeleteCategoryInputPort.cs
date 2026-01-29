using AppStore.Entities.DTOs.Categories.DeleteCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Categories.DeleteCategory
{
    public interface IDeleteCategoryInputPort
    {
        Task Handle(DeleteCategoryDto dto);
    }
}
