using Application.DTOs.SupplierDto.Request;
using Application.Interfaces.IServices;
using Application.Mapping;
using Application.Services;
using AutoMapper;
using Infrastructure.Repository;


namespace Test.ServicesTest
{
    public class SupplierServiceTest
    {
        private readonly ISupplierService _serv;
        private readonly DataFixture _db;
        private readonly IMapper _mapper;
        public static Guid _SupplierId;
        public SupplierServiceTest()
        {
            _db = new DataFixture();
            var Rep = new SupplierRepository(_db.Context);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SupplierMapProfile>();
            });
            _mapper = config.CreateMapper();
            _serv = new SupplierService(Rep, _mapper);
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

            var request = new SupplierCreateRequest
            {
                CompanyName = "Acme Corporation",
                ContactInfo = "123 Main Street, Anytown, USA"
            };

            var responce = await _serv.CreateAsync(request, CancellationToken.None);

            _SupplierId = responce.Id;

            Console.WriteLine(responce is null ? "Error Create" + responce : "Supplier Created" + responce.Id);
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

            var responce = await _serv.GetByIdAsync(_SupplierId, CancellationToken.None);

            Console.WriteLine(responce is null ? "Error" + responce : "Success");
        }
        private async Task TestUpdate()
        {
            Console.WriteLine("Тестирование метода Update:");
            var request = new SupplierUpdateRequest
            {
                Id = _SupplierId,
                CompanyName = "NEW NEW",
                ContactInfo = "NEW NEW"
            };
            var responce = await _serv.UpdateAsync(request, CancellationToken.None);

            Console.WriteLine(responce is null ? "Error Update" + responce : "Update Success");
        }

        private async Task TestDelete()
        {
            Console.WriteLine("Тестирование метода Delete:");

            var responce = await _serv.DeleteAsync(_SupplierId, CancellationToken.None);

            Console.WriteLine(responce is false ? "Error Delete" + responce : "Supplier Deleted");

        }
    }
}
