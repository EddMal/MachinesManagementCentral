using MachinesManagementCentral.Client.Services;
using MachinesManagementCentral.Shared.Domains;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace MachinesManagementCentral.Client.Pages
{
    public partial class DeviceView
    {
        [Parameter]
        public string DeviceId { get; set; }
        
        public Device Device { get; set; } = new Device();

        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }

        public List<Device> DeviceLst { get; set; } = new List<Device>();

        public string responseData = string.Empty;

        public bool Error = false;

        protected override async Task OnInitializedAsync()
        {
    
            var response = await Http.GetAsync("/device/" + DeviceId);

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true,
                };

                responseData = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(responseData))
                {
                    Device = JsonSerializer.Deserialize<Device>(responseData, options);
                }
            }
            else 
            {
                Error = true;
            }
           
            await base.OnInitializedAsync();

        }

    }
}
