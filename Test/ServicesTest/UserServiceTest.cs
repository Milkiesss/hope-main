using Application.DTOs.UserDto.Request;
using Application.Interfaces.IServices;
using Application.Mapping;
using Application.Services;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repository;

namespace Test.ServicesTest
{
    public class UserServiceTest
    {
        private readonly IUserService _serv;
        private readonly DataFixture _db;
        private readonly IMapper _mapper;
        public static Guid _UserId;

        private static string _Email;
        private static string _Password;
        public UserServiceTest()
        {
            _db = new DataFixture();
            var Rep = new UserRepository(_db.Context);
            var cryptserv = new CryptographyService();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserMapProfile>();
            });
            _mapper = config.CreateMapper();
            _serv = new UserService(Rep, cryptserv, _mapper);
        }
        public async Task StartTest()
        {
            await TestCreate();
            await TestGetLIst();
            await TestGetById();
            await TestLogin();
            await TestUpdate();
        }

        private async Task TestCreate()
        {
            Console.WriteLine("Тестирование метода Create:");

            var request = new UserCreateRequest
            {
                Email = "bob.johnson@example.com",
                FullName = "Bob Johnson",
                Address = "789 Oak Lane, Metropolis, USA",
                Password = "abc123"
            };

            var responce = await _serv.CreateAsync(request, CancellationToken.None);

            _UserId = responce.Id;
            _Email = responce.Email;
            _Password = "abc123";

            Console.WriteLine(responce is null ? "Error Create" + responce : "User Created" + responce.Id);
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

            var responce = await _serv.GetByIdAsync(_UserId, CancellationToken.None);

            Console.WriteLine(responce is null ? "Error" + responce : "Success");
        }
        private async Task TestLogin()
        {
            Console.WriteLine("Тестирование метода Login:");
            var requset = new UserLoginRequest
            {
                Email = _Email,
                Password = _Password
            };
            var responce = await _serv.LoginAsync(requset, CancellationToken.None);

            Console.WriteLine(responce is Guid ? "Login Success" : "Error Login" + responce);

        }
        private async Task TestUpdate()
        {
            Console.WriteLine("Тестирование метода Update:");
            var request = new UserUpdateRequest
            {
                Id = _UserId,
                Email = "NEW123@example.com",
                FullName = "NEW NEW NEW",
                Address = "789 Oak Lane, Metropolis, NEW",
                Password = "NEW123"
            };
            var responce = await _serv.UpdateAsync(request,CancellationToken.None);

            Console.WriteLine(responce is null ? "Error Update" + responce : "Update Success");
        }
        public async Task TestDelete()
        {
            Console.WriteLine("Тестирование метода Delete:");

            var responce = await _serv.DeleteAsync(_UserId, CancellationToken.None);

            Console.WriteLine(responce is false ? "Error Delete" + responce : "User Deleted");

        }
    }
}
