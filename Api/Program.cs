using Api.Helpers;
using Application.Interfaces.IRepository;
using Application.Interfaces.IServices;
using Application.Services;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.InjectDepencies(builder.Configuration);

        var app = builder.Build();
        app.ConfigureApplication();
        app.Run();
    }
}