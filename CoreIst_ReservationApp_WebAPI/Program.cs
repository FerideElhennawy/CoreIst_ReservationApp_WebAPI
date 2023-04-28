using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CoreIst_ReservationApp_WebAPI.Data;
namespace CoreIst_ReservationApp_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CoreIst_ReservationApp_WebAPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CoreIst_ReservationApp_WebAPIContext") ?? throw new InvalidOperationException("Connection string 'CoreIst_ReservationApp_WebAPIContext' not found."))

                //options.UseInMemoryDatabase("CoreIst")
            );
                

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseCors(s => s.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                //app.UseCors(s => s.WithOrigins(new[] { "http://localhost:4200" }));
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}