using Application.DTOs.OrderDto;
using Application.DTOs.OrderDto.Request;
using Application.DTOs.SupplierDto.Request;
using Application.Interfaces.IServices;
using Application.Mapping;
using Application.Services;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ServicesTest
{
    public class OrderServiceTest
    {
        private readonly IOrderService _serv;
        private readonly DataFixture _db;
        private readonly IMapper _mapper;
        public static Guid _OrderId;
        public OrderServiceTest()
        {
            _db = new DataFixture();
            var Rep = new OrderRepository(_db.Context);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<OrderMapProfile>();
            });
            _mapper = config.CreateMapper();
            _serv = new OrderService(Rep, _mapper);
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

            var request = new OrderCreateRequest
            {
                UserId = UserServiceTest._UserId,
                items = new List<BaseItemOrderDto>
                {
                    new BaseItemOrderDto
                    {
                        ProductId = ProductServiceTest._ProductId,
                        Quantity = 10
                    }
                }
            };

            var responce = await _serv.CreateAsync(request, CancellationToken.None);

            _OrderId = responce.Id;

            Console.WriteLine(responce is null ? "Error Create" + responce : "Order Created" + responce.Id);
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

            var responce = await _serv.GetByIdAsync(_OrderId, CancellationToken.None);

            Console.WriteLine(responce is null ? "Error" + responce : "Success");
        }
        private async Task TestUpdate()
        {
            Console.WriteLine("Тестирование метода Update:");
            var request = new OrderUpdateRequest
            {
                Id = _OrderId,
                UserId = UserServiceTest._UserId,
                items = new List<BaseItemOrderDto>
                {
                    new BaseItemOrderDto
                    {
                        ProductId = ProductServiceTest._ProductId,
                        Quantity = 1
                    }
                }
            };
            var responce = await _serv.UpdateAsync(request, CancellationToken.None);

            Console.WriteLine(responce is null ? "Error Update" + responce : "Update Success");
        }

        private async Task TestDelete()
        {
            Console.WriteLine("Тестирование метода Delete:");

            var responce = await _serv.DeleteAsync(_OrderId, CancellationToken.None);

            Console.WriteLine(responce is false ? "Error Delete" + responce : "Order Deleted");

        }
    }
}
