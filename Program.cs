using Microsoft.EntityFrameworkCore;
using VictoryGarden_BackEnd.Services;

namespace VictoryGarden_BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200",
                                            "https://jolly-island-03229f60f.5.azurestaticapps.net",// might need to update
                                            "https://MyApp.com/api")
                        .AllowAnyMethod() // method in this context means GET, POST, PUT, DELETE, etc. 
                        .AllowAnyHeader();
                    });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<VictoryGardenDbContext>(options =>
            {
                // ConnectionStrings:DefaultConnection
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });
            builder.Services.AddHttpClient<TrefleService>(client => {client.BaseAddress = new Uri("https://trefle.io/api/v1/plants/");});

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseDeveloperExceptionPage();

            app.UseSwagger();

            app.UseSwaggerUI();
            
            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
