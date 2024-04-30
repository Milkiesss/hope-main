

namespace Domain.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public Category(Guid id, string categoryName)
        {
            SetId(id);
            CategoryName = categoryName;
        }
        public Category() {}
    }
}
