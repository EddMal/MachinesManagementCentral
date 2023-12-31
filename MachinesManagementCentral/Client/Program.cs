using MachinesManagementCentral.Client;
using MachinesManagementCentral.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace MachinesManagementCentral.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddHttpClient("MachinesManagementCentral.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MachinesManagementCentral.ServerAPI"));

            builder.Services.AddApiAuthorization();

            var apibaseAddress = "https://localhost:7231";
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apibaseAddress) });

            builder.Services.AddSingleton<IDeviceDataService, DeviceDataService>();

            await builder.Build().RunAsync();
        }
    }
}
