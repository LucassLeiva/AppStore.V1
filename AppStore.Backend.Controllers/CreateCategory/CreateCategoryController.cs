using AppStore.Backend.BusinessObjects.Interfaces.CreateCategory;
using AppStore.Entities.DTOs.CreateCategory;
using AppStore.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder;

public static class CreateCategoryController
{
    public static WebApplication UseCreateCategoryController(this WebApplication app)
    {
        app.MapPost(Endpoints.CreateCategory, CreateCategory);
        return app;
    }

    public static async Task<int> CreateCategory(
        CreateCategoryDto dto,
        ICreateCategoryInputPort inputPort,
        ICreateCategoryOutputPort presenter)
    {
        await inputPort.Handle(dto);
        return presenter.IdCategory;
    }
}
