using AppStore.Backend.BusinessObjects.Interfaces.CreateCategory;
using AppStore.Entities.DTOs.CreateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.UseCases.CreateCategory
{
    internal class CreateCategoryInteractor(
        ICreateCategoryOutputPort outputPort,
        ICommandsRepository repository) : ICreateCategoryInputPort
    {
        public async Task Handle(CreateCategoryDto dto)
        {
            var category = new Category(dto.Name, dto.Description);

            int id = await repository.CreateCategory(category);
            category.IdCategory = id;

            await outputPort.Handle(category);
        }
    }
}
