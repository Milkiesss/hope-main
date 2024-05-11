using Application.DTOs.ProductDto.Request;
using Application.Interfaces.IServices;
using Application.Mapping;
using Application.Services;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repository;


namespace Test.ServicesTest
{
    public class ProductServiceTest
    {
        private readonly IProductService _serv;
        private readonly DataFixture _db;
        private readonly IMapper _mapper;
        public static Guid _ProductId;
        public ProductServiceTest()
        {
            _db = new DataFixture();
            var Rep = new ProductRepository(_db.Context);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductMapProfile>();
            });
            _mapper = config.CreateMapper();
            _serv = new ProductService(Rep, _mapper);
        }
        public async Task StartTest()
        {
            await TestCreate();
            await TestGetLIst();
            await TestGetById();
            await TestUpdate();
            await TestDelete();
        }
        public async Task TestCreate()
        {
            Console.WriteLine("Тестирование метода Create:");

            var request = new ProductCreateRequest
            {
                Name = "Apples", 
                UnitOfMeasure = "kg",
                Available = true,
                Price = 1.2,
                ExpiryDate = DateTime.Now.AddDays(30),
                CategoryId = CategoryServiceTest._CategoryId,
                SupplierId = SupplierServiceTest._SupplierId,
            };

            var responce = await _serv.CreateAsync(request, CancellationToken.None);

            _ProductId = responce.Id;

            Console.WriteLine(responce is null ? "Error Create" + responce : "Product Created" + responce.Id);
        }
        private async Task TestGetLIst()
        {
            Console.WriteLine("Тестирование метода GetList:");

            var responce = await _serv.GetAllAsync(CancellationToken.None);

            Console.WriteLine(responce is null ? "Error" + responce : "Success");
        }
        private async Task TestGetById()
        {
            Console.WriteLine("Тестирование метода GetById:");

            var responce = await _serv.GetByIdAsync(_ProductId, CancellationToken.None);

            Console.WriteLine(responce is null ? "Error" + responce : "Success");
        }
        private async Task TestUpdate()
        {
            Console.WriteLine("Тестирование метода Update:");
            var request = new ProductUpdateRequest
            {
                Id = _ProductId,
                Name = "NEW",
                UnitOfMeasure = "NEW",
                Available = true,
                Price = 10,
                ExpiryDate = DateTime.Now.AddDays(30),
                CategoryId = CategoryServiceTest._CategoryId,
                SupplierId = SupplierServiceTest._SupplierId,
            };
            var responce = await _serv.UpdateAsync(request, CancellationToken.None);

            Console.WriteLine(responce is null ? "Error Update" + responce : "Update Success");
        }

        private async Task TestDelete()
        {
            Console.WriteLine("Тестирование метода Delete:");

            var responce = await _serv.DeleteAsync(_ProductId, CancellationToken.None);

            Console.WriteLine(responce is false ? "Error Delete" + responce : "Product Deleted");

        }
    }
}

