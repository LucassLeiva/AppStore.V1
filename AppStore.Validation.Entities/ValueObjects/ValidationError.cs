using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Validation.Entities.ValueObjects
{
    public class ValidationError(string propertyName, string message)
    {
        public string PropertyName => propertyName;
        public string Message => message;
    }
}
