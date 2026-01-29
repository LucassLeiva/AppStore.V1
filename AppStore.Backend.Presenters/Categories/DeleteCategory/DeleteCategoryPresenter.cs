using AppStore.Backend.BusinessObjects.Interfaces.Categories.DeleteCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.Presenters.Categories.DeleteCategory
{
    internal class DeleteCategoryPresenter : IDeleteCategoryOutputPort
    {
        public int IdCategory { get; private set; }

        public Task Handle(int idCategory)
        {
            IdCategory = idCategory;
            return Task.CompletedTask;
        }
    }
}
