using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Entities.DTOs.Categories.GetCategories
{
    public class CategoryItemDto(int idCategory, string name, string? description, int state)
    {
        public int IdCategory => idCategory;
        public string Name => name;
        public string? Description => description;
        public int State => state;
    }
}
