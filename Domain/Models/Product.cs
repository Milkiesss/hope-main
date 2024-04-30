namespace Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
        public int Quantity { get; set; }
        public bool Available { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public Product(Guid Id,string name, string unitOfMeasure, int quantity, bool available, DateTime expiryDate, Guid categoryId, Guid supplierId)
        {
            SetId(Id);
            Name = name;
            UnitOfMeasure = unitOfMeasure;
            Quantity = quantity;
            Available = available;
            ExpiryDate = expiryDate;
            CategoryId = categoryId;
            SupplierId = supplierId;
        }
    }
}
