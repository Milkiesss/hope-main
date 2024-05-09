

using Domain.Validation.Validators;
using Domain.Validators;

namespace Domain.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public Category(Guid id, string categoryName)
        {
            SetId(id);
            CategoryName =categoryName;
            new CategoryValidator(nameof(Category)).ValidateWithErrors(this);
        }
        public Category() {}
    }
}
