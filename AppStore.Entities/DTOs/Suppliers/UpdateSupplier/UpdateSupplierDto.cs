using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Entities.DTOs.Suppliers.UpdateSupplier
{
        public class UpdateSupplierDto(
            int idSupplier,
            string name,
            string cuit,
            string address,
            string phoneNumber,
            string email,
            string city,
            string country,
            string postcode
        )
        {
            public int IdSupplier => idSupplier;
            public string Name => name;
            public string CUIT => cuit;
            public string Address => address;
            public string PhoneNumber => phoneNumber;
            public string Email => email;
            public string City => city;
            public string Country => country;
            public string Postcode => postcode;
        }
    
}
