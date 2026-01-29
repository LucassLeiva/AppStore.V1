using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Entities.DTOs.Categories.DeleteCategory
{
    public class DeleteCategoryDto(int idCategory)
    {
        public int IdCategory => idCategory;
    }
}
