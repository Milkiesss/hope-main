using Application.Interfaces.IRepository;
using Application.Interfaces.IServices;
using Application.Mapping;
using Application.Services;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


namespace Api.Helpers
{
    public static class DependenciesHelper
    {
        internal static IServiceCollection InjectDepencies(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("https://localhost:7265",
                        "http://localhost:5271")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddDbContext<DataContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddServices();
            services.AddEndpointsApiExplorer();
            services.AddControllers();
            services.AddSwagger();
            services.AddCors();
            services.AddAutoMapper(typeof(AutoMapperConfig));

            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IProductService, ProductService>();

            service.AddScoped<ISupplierRepositoty, SupplierRepository>();
            service.AddScoped<ISupplierService, SupplierService>();

            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<ICategoryService, CategoryService>();

            return service;
        }
        private static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SukaBlyat",
                    Version = "v1"
                });
            });
            return services;
        }
    }
}
