using MachinesManagementCentral.Client.Services;
using MachinesManagementCentral.Shared.Domains;
using Microsoft.AspNetCore.Components;

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


        protected override void OnInitialized()
        {
            Device = DeviceDataService.GetDevice(int.Parse(DeviceId));
            DeviceHistory = Device;
            base.OnInitialized();
        }

        protected async Task HandleValidSubmit()
        {
            //add error handling/control
            DeviceDataService.UpdateDevice(Device);
            NavigationManager.NavigateTo($"/DeviceLst");

        }

    }
}

