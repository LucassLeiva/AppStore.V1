using AppStore.Entities.DTOs.Categories.UpdateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Categories.UpdateCategory
{
    public interface IUpdateCategoryInputPort
    {
        Task Handle(UpdateCategoryDto dto);
    }
}
