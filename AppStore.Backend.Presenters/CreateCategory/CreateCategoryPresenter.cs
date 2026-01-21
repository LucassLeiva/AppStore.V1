using AppStore.Backend.BusinessObjects.Interfaces.CreateCategory;
using AppStore.Backend.BusinessObjects.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.Presenters.CreateCategory
{
    internal class CreateCategoryPresenter : ICreateCategoryOutputPort
    {
        public int IdCategory { get; private set; }

        public Task Handle(Category addedCategory)
        {
            IdCategory = addedCategory.IdCategory;
            return Task.CompletedTask;
        }
    }
}
