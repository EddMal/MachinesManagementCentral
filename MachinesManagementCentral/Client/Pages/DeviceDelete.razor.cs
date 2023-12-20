using MachinesManagementCentral.Client.Services;
using MachinesManagementCentral.Shared.Domains;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Diagnostics;

namespace MachinesManagementCentral.Client.Pages
{
    public partial class DeviceDelete
    {

        [Parameter]
        public string DeviceId { get; set; }

        public Device Device { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }

        public List<Device> DeviceLst { get; set; } = new List<Device>();

        public string responseData = string.Empty;

        bool Error = false;

        public string statusCode = string.Empty;


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
        protected async Task DeleteAsync()
        {

            var response = await Http.DeleteAsync("device/delete/" + Device.DeviceId);
            if (response.IsSuccessStatusCode)
            {

                //Remove or move alert into other file
                NavigationManager.NavigateTo($"/DeviceLst");

            }
            else
            {
                Error = true;
            }
        }
            protected async Task DeleteErrorAsync()
            {

                var response = await Http.DeleteAsync("device/delete/1011");
                statusCode = await response.Content.ReadAsStringAsync();

            }

    }
}
