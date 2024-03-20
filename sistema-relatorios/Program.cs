
using Microsoft.EntityFrameworkCore;
using sistema_relatorios.database;

namespace sistema_relatorios
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

            // Register ApplicationDbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });

            app.MapControllers();

            app.MapControllerRoute(name: "default", pattern: "{controller=UserController}/{action=Index}/{id?}");
            app.MapControllerRoute(name: "default", pattern: "{controller=TaxRuleController}/{action=Index}/{id?}");
            app.MapControllerRoute(name: "default", pattern: "{controller=ProductController}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
