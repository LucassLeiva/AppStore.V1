using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Validation.Entities.Abstractions
{
    public abstract class AbstractViewModelValidator<DtoType, ViewModelType>(
            IModelValidatorHub<DtoType> dtoModelValidatorHub,
            ValidationConstraint constraint) : IModelValidator<ViewModelType>
    {
        public ValidationConstraint Constraint => constraint;
        public IEnumerable<ValidationError> Errors => dtoModelValidatorHub.Errors;

        // En caso de que el ViewModel implemente el operador Explicit se puede
        // utilizar este método.
        // Si el ViewModel no implementa el operador Explicit, se podrá remplazar
        // (Override) este método en la clase que implemente esta clase.
        //public virtual DtoType Cast(ViewModelType viewModel)
        //{
        //    CODIGO ANTIGUO
        //    DtoType DtoModel = default;
        //    var ExplicitMethod = typeof(ViewModelType).GetMethod("op_Explicit");
        //    if (ExplicitMethod != null)
        //        DtoModel = (DtoType)ExplicitMethod.Invoke(
        //        viewModel, new object[] { viewModel });
        //    else
        //        throw new InvalidCastException();
        //    return DtoModel;


        //}
        //    public Task<bool> Validate(ViewModelType model) =>
        //   dtoModelValidatorHub.Validate(Cast(model));
        //}

        public virtual DtoType Cast(ViewModelType viewModel)
        {
            if (viewModel is null)
                throw new ArgumentNullException(nameof(viewModel));

            // Buscar el operador explícito EXACTO: ViewModelType -> DtoType
            var explicitMethod = typeof(ViewModelType)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .SingleOrDefault(m =>
                    m.Name == "op_Explicit" &&
                    m.ReturnType == typeof(DtoType) &&
                    m.GetParameters().Length == 1 &&
                    m.GetParameters()[0].ParameterType == typeof(ViewModelType)
                );

            if (explicitMethod is null)
            {
                throw new InvalidCastException(
                    $"No se encontró un operador explícito 'op_Explicit' que convierta {typeof(ViewModelType).Name} -> {typeof(DtoType).Name}."
                );
            }

            // op_Explicit es STATIC, así que el target es null
            var dto = explicitMethod.Invoke(null, new object[] { viewModel });

            return (DtoType)dto!;
        }

        public Task<bool> Validate(ViewModelType model) =>
            dtoModelValidatorHub.Validate(Cast(model));
    }
       
}
