using Microsoft.EntityFrameworkCore;
using PizzaApp.Contexts;
using PizzaApp.Interfaces;
using PizzaApp.Models;
using PizzaApp.Repositories;
using PizzaApp.Services;

namespace PizzaApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Context Injection
            builder.Services.AddDbContext<PizzaAppContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
                );
            #endregion

            #region Repository Injections
            builder.Services.AddScoped<IRepository<int,User>, UserRepository>();
            builder.Services.AddScoped<IRepository<int,UserCredential>, UserCredentialRepository>();
            builder.Services.AddScoped<IRepository<int, Pizza>, PizzaRepository>();
            #endregion

            #region Service Injections
            builder.Services.AddScoped<IUserAuthService, UserAuthService>();
            builder.Services.AddScoped<IPizzaService, PizzaService>();
            #endregion



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
