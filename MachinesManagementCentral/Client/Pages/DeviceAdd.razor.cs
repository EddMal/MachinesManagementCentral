using MachinesManagementCentral.Client.Services;
using MachinesManagementCentral.Shared.Domains;
using Microsoft.AspNetCore.Components;

namespace MachinesManagementCentral.Client.Pages
{
    public partial class DeviceAdd
    {


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }

        public Device Device { get; set; } = new Device();


        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected async Task HandleValidSubmit()
        {
            //Error handling/control
            DeviceDataService.AddDevice(Device);
            NavigationManager.NavigateTo($"/DeviceLst");

        }
    }
}
