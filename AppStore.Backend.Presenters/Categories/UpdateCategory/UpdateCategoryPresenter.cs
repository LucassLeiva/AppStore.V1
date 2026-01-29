using AppStore.Backend.BusinessObjects.Interfaces.Categories.UpdateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.Presenters.Categories.UpdateCategory
{
    internal class UpdateCategoryPresenter : IUpdateCategoryOutputPort
    {
        public int IdCategory { get; private set; }

        public Task Handle(Category updatedCategory)
        {
            IdCategory = updatedCategory.IdCategory;
            return Task.CompletedTask;
        }
    }
}
