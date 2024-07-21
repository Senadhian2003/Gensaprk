using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using VmSqlDemoApp.Context;
using VmSqlDemoApp.Models;
using VmSqlDemoApp.Repositories;
using VmSqlDemoApp.Services;
using VmSqlDemoApp.Services.Interfaces;

namespace VmSqlDemoApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //var keyVaultName = "sena-key-vault";
            //const string secretName = "sql-connection-string";

            //var kvUri = $"https://{keyVaultName}.vault.azure.net";

            //var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());



            //Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
            //var secret = await client.GetSecretAsync(secretName);
            //string connectionString = secret.Value.Value;
            //Console.WriteLine($"Your secret is '{connectionString}'.");

            //builder.Services.AddDbContext<ProductContext>(
            //options => options.UseSqlServer(connectionString)
            //);

            String connectionString = "Data source=4N8CBX3\\SQLEXPRESS;Integrated Security=true;Initial catalog=ProductDB";

            builder.Services.AddDbContext<ProductContext>(
           options => options.UseSqlServer(connectionString)
           );

            #region CORS
            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("MyCors", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            #endregion

            #region Dependency Injection

            builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IBlobService, BlobService>();
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyCors");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
