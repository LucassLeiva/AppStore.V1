using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.POCOEntities
{
    public class Category
    {
        public int IdCategory { get; set; }
        public string Name { get; private set; } = default!;
        public string? Description { get; private set; }
        public int State { get; private set; } = 1;

        protected Category() { }

        public Category(string name, string? description)
        {
            Name = name;
            Description = description;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Category name is required.");

            if (Name.Length > 100)
                throw new ArgumentException("Category name max length is 100.");
        }
    }
}
