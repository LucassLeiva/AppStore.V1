using AppStore.Backend.BusinessObjects.Interfaces.CreateSupplier;
using AppStore.Entities.DTOs.CreateSupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class CreateSupplierController
    {
        public static WebApplication UseCreateSupplierController(this WebApplication app)
        {
            app.MapPost(Endpoints.CreateSupplier, CreateSupplier);
            return app;
        }

        public static async Task<int> CreateSupplier(
            CreateSupplierDto dto,
            ICreateSupplierInputPort inputPort,
            ICreateSupplierOutputPort presenter)
        {
            await inputPort.Handle(dto);
            return presenter.IdSupplier;
        }
    }
}
