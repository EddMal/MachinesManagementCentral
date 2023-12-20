using MachinesManagementCentral.Client.Services;
using MachinesManagementCentral.Shared.Domains;
using Microsoft.AspNetCore.Components;
using System.Text.Json;


using System.Net.Http.Headers;

namespace MachinesManagementCentral.Client.Pages
{
    public partial class DeviceUpdate
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }

        public Device Device { get; set; } = new Device();
        private Device DeviceHistory { get; set; } = new Device();

        [Parameter]
        public string DeviceId { get; set; } = string.Empty;

        public string responseData = string.Empty;


        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected async Task HandleValidSubmitAsync()
        {
            var json = JsonSerializer.Serialize(Device);
            var httpContent = new StringContent(json, new MediaTypeHeaderValue("application/json"));

            var response = await Http.PostAsync("/device/add", httpContent);
            if (response.IsSuccessStatusCode)
            {

                responseData = await response.Content.ReadAsStringAsync();
                
            }



            //NavigationManager.NavigateTo($"/DeviceLst");

        }

    }
}

