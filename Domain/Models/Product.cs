namespace Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
        public bool Available { get; set; }
        public DateTime ExpiryDate { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public Product(Guid Id,string name, string unitOfMeasure, bool available, DateTime expiryDate,double price, Guid categoryId, Guid supplierId)
        {
            SetId(Id);
            Name = name;
            UnitOfMeasure = unitOfMeasure;
            Available = available;
            ExpiryDate = expiryDate;
            Price = price;
            CategoryId = categoryId;
            SupplierId = supplierId;
        }
    }
}
