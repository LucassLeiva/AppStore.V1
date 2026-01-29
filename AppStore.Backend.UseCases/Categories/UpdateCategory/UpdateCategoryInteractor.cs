using AppStore.Backend.BusinessObjects.Interfaces.Categories.UpdateCategory;
using AppStore.Entities.DTOs.Categories.UpdateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.UseCases.Categories.UpdateCategory
{
    internal class UpdateCategoryInteractor(
        IUpdateCategoryOutputPort outputPort,
        ICommandsRepository repository) : IUpdateCategoryInputPort
    {
        public async Task Handle(UpdateCategoryDto dto)
        {
            var category = new Category(dto.Name, dto.Description)
            {
                IdCategory = dto.IdCategory
            };

            
            int id = await repository.UpdateCategory(category);
            await outputPort.Handle(category);
        }
    }
}
