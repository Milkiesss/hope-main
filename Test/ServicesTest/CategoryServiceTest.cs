using Application.DTOs.CategoryDto.Request;
using Application.Interfaces.IServices;
using Application.Mapping;
using Application.Services;
using AutoMapper;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Test.ServicesTest
{
    public class CategoryServiceTest
    {

        private readonly ICategoryService _serv;
        private readonly DataFixture _db;
        private readonly IMapper _mapper;
        public static Guid _CategoryId;
        public CategoryServiceTest()
        {
            _db = new DataFixture();
            var Rep = new CategoryRepository(_db.Context);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CategoryMapProfile>();
            });
            _mapper = config.CreateMapper();
            _serv = new CategoryService(Rep, _mapper);
        }
        public async Task StartTest()
        {
            await TestCreate();
            await TestGetById();
            await TestGetLIst();
            await TestUpdate();
            await TestDelete();
        }
        public async Task TestCreate()
        {
            Console.WriteLine("Тестирование метода Create:");

            var request = new CategoryCreateRequest
            {
                СategoryName = "Dairy"
            };

            var responce = await _serv.CreateAsync(request, CancellationToken.None);

            _CategoryId = responce.Id;
            Console.WriteLine(responce is null ? "Error Create" : "Category Created" + responce.Id);
        }
        private async Task TestGetLIst()
        {
            Console.WriteLine("Тестирование метода GetList:");

            var responce = await _serv.GetAllAsync(CancellationToken.None);

            Console.WriteLine(responce is null ? "Error" : "Success");
        }
        private async Task TestGetById()
        {
            Console.WriteLine("Тестирование метода GetById:");

            var responce = await _serv.GetByIdAsync(_CategoryId, CancellationToken.None);
 
            Console.WriteLine(responce is null ? "Error" : "Success");
        }
        private async Task TestUpdate()
        {
            Console.WriteLine("Тестирование метода Update:");

            var request = new CategoryUpdateRequest
            {
                Id = _CategoryId,
                СategoryName = "NEW"
            };

            var responce = await _serv.UpdateAsync(request, CancellationToken.None);

            Console.WriteLine(responce is null ? "Error Update" : "Update Success");
        }

        private async Task TestDelete()
        {
            Console.WriteLine("Тестирование метода Delete:");

            var responce = await _serv.DeleteAsync(_CategoryId, CancellationToken.None);

            Console.WriteLine(responce is false ? "Error Delete" : "Category Deleted");

        }
    }
}
