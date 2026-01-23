using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Validation.Entities.Interfaces
{
    public interface IValidationService<T>
    {
        IValidationRules<T, TProperty> AddRuleFor<TProperty>(
        Expression<Func<T, TProperty>> expression);
        ICollectionValidationRules<T, TProperty> AddRuleForEach<TProperty>(
        Expression<Func<T, IEnumerable<TProperty>>> expression);
        Task<IEnumerable<ValidationError>> Validate(T model);
    }
}
