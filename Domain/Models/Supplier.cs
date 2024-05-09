using Domain.Validation.Validators;
using Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Supplier : BaseEntity
    {
        public string CompanyName { get; set; }
        public string ContactInfo { get; set; }
        public Supplier(Guid id,string companyName, string contactInfo) 
        {
            SetId(id);
            CompanyName = companyName; 
            ContactInfo =contactInfo;
            new SupplierValidator(nameof(Supplier)).ValidateWithErrors(this);
        }
        public Supplier(){}
        //public Supplier(Guid id) 
        //{
        //    SetId(id);
        //}
    }
}
