using Application.DTOs.OrderDto;
using Domain.Models;
using Infrastructure;
using Org.BouncyCastle.Tls;
using Test.ServicesTest;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            while(true) 
            {
                try
                {
                    Console.WriteLine("Выберите, что вы хотите протестировать:");
                    Console.WriteLine("0. База Данных.");
                    Console.WriteLine("1. Сервис Cetegory");
                    Console.WriteLine("2. Сервис Supplier");
                    Console.WriteLine("3. Сервис Product");
                    Console.WriteLine("4. Сервис User");
                    Console.WriteLine("5. Сервис Order");
                    Console.WriteLine("6. Выйти");
                    Console.Write("Введите номер: ");
                    c:
                    string choise = Console.ReadLine();
                    
                    switch(choise)
                    {
                        case "0":
                            Initialize(new DataFixture().Context);
                            goto c;
                        case "1":
                            new CategoryServiceTest().StartTest().GetAwaiter().GetResult();
                            goto c;
                        case "2":
                            new SupplierServiceTest().StartTest().GetAwaiter().GetResult();
                            goto c;
                        case "3":
                            new ProductServiceTest().StartTest().GetAwaiter().GetResult();
                            goto c;
                        case "4":
                            new UserServiceTest().StartTest().GetAwaiter().GetResult();
                            goto c;
                        case "5":
                            new OrderServiceTest().StartTest().GetAwaiter().GetResult();
                            new ProductServiceTest().TestDelete().GetAwaiter().GetResult();
                            new CategoryServiceTest().TestDelete().GetAwaiter().GetResult();
                            new SupplierServiceTest().TestDelete().GetAwaiter().GetResult();
                            new UserServiceTest().TestDelete().GetAwaiter().GetResult();
                            goto c;
                        case "6":
                            return;
                            break;
                    }
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        private static void Initialize(DataContext _db)
        {
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
            var Supplier = new Supplier
            { 
                CompanyName = "TESTCompany 1",
                ContactInfo = "Company info"
            };
            _db.suppliers.Add(Supplier);
            _db.SaveChanges();

            var Category = new Category
            { 
                CategoryName = "TEST Category"
            };
            _db.categories.Add(Category);
            _db.SaveChanges();
            
            var Product = new Product
            {
                Name = "TEST",
                UnitOfMeasure = "kg",
                Available = true,
                Price = 1.2,
                ExpiryDate = DateTime.Now.AddDays(30),
                CategoryId = Category.Id,
                SupplierId = Supplier.Id,
            };
            _db.products.Add(Product);
            _db.SaveChanges();

            var User = new User
            {
                Email = "TESTbob.johnson@example.com",
                FullName = "TESTBob Johnson",
                Address = "789 Oak Lane, Metropolis, USA",
                PasswordHash = "abc123"
            };
            _db.users.Add(User);
            _db.SaveChanges();

            var Order = new Order 
            {
                UserId = User.Id,
                items = new List<ItemOrder>
                {
                    new ItemOrder
                    {
                        ProductId = Product.Id,
                        Quantity = 10
                    }
                }
            };
            _db.orders.Add(Order); 
            _db.SaveChanges();
            Console.WriteLine("Данные добавлены");

            _db.orders.Remove(Order);
            _db.products.Remove(Product);
            _db.suppliers.Remove(Supplier);
            _db.categories.Remove(Category);
            _db.users.Remove(User);

            _db.SaveChanges();
            Console.WriteLine("Данные удалены");
        }
    }
}
