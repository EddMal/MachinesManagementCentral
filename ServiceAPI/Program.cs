
using MachinesManagementCentral.Shared.Domains;

namespace ServiceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var specificOrigin = "MySpecOrigin";

            builder.Services.AddCors(options =>
                options.AddPolicy(name: specificOrigin,
                //managementCentral.Server => launchsettings.json
                policy => policy.WithOrigins("https://localhost:7092") 
                .AllowAnyHeader()           
                .AllowAnyMethod()));

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            app.MapGet("/device", () => "Getting a device from API");

            app.MapGet("/device/{deviceId}/button/{buttonID}",
                (int deviceId, int buttonId) => $"DeviceId {deviceId} and ButtonId {buttonId}");

            app.MapGet("/device/{deviceId}", (int deviceId) =>
            {
                var DeviceService = new DeviceService();
                return DeviceService.Devices[deviceId].DeviceType;
            });


            app.UseCors(specificOrigin);
            app.Run();
        }

            //Should be placed elsewhere.
            class DeviceService
            { 
            
   
                public List<Device> Devices { get; set; } = new List<Device>();

                public DeviceService()
                {
                    Devices.Add(new Device()
                    {
                        DeviceId = 1,
                        Location = Location.Sweden,
                        Date = DateTime.Now,
                        DeviceType = "CoffeeMakerx4000",
                        Status = Status.Offline
                    });

                    Devices.Add(new Device()
                    {
                        DeviceId = 2,
                        Location = Location.England,
                        Date = DateTime.Now,
                        DeviceType = "Saw",
                        Status = Status.Online
                    });

                    Devices.Add(new Device()
                    {
                        DeviceId = 3,
                        Location = Location.Sweden,
                        Date = DateTime.Now,
                        DeviceType = "CoffeeMakerx4000",
                        Status = Status.Online
                    });

                    Devices.Add(new Device()
                    {
                        DeviceId = 4,
                        Location = Location.England,
                        Date = DateTime.Now,
                        DeviceType = "Saw",
                        Status = Status.Offline
                    });

                    Devices.Add(new Device()
                    {
                        DeviceId = 5,
                        Location = Location.England,
                        Date = DateTime.Now,
                        DeviceType = "Saw",
                        Status = Status.Offline
                    });
            }
        
        }
    }
}
