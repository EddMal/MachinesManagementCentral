
using DeviceAPI.Endpoints;
using Microsoft.Extensions.Options;
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
            //builder.Services.AddAuthorization();

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

            //app.UseAuthorization();

            app.RegisterUserEndpoint();
           
            app.UseCors(specificOrigin);
            app.Run();
         

            //app.MapGet("/device", () => "Getting a device from API");

            //app.MapGet("/device/{deviceId}/button/{buttonID}",
            //    (int deviceId, int buttonId) => $"DeviceId {deviceId} and ButtonId {buttonId}");

            //app.MapGet("/device/{deviceId}", (int deviceId) =>
            //{
            //    var DeviceService = new DeviceService();
            //    return DeviceService.Devices[deviceId].DeviceType;
            //});


        }

        
    }
}
