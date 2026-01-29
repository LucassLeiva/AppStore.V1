using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Entities.DTOs.Categories.CreateCategory
{
    public class CreateCategoryDto(string name, string? description)
    {
        public string Name => name;
        public string? Description => description;
    }
}
