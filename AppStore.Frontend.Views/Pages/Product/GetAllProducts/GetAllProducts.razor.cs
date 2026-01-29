using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Frontend.Views.Pages.Product.GetAllProducts
{
    public partial class GetAllProducts
    {
        [Inject]
        GetAllProductsViewModel ViewModel { get; set; } = default!;

        ErrorBoundary? ErrorBoundaryRef;

        void Recover()
        {
            ErrorBoundaryRef?.Recover();
        }
    }
}
