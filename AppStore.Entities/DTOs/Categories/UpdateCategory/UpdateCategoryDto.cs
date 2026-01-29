namespace AppStore.Entities.DTOs.Categories.UpdateCategory
{
    public class UpdateCategoryDto(int idCategory, string name, string? description)
    {
        public int IdCategory => idCategory;
        public string Name => name;
        public string? Description => description;
    }
}
