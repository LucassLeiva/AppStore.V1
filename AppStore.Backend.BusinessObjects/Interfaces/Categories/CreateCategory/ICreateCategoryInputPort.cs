using AppStore.Entities.DTOs.Categories.CreateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Categories.CreateCategory
{
    public interface ICreateCategoryInputPort
    {
        Task Handle(CreateCategoryDto dto);
    }
}
