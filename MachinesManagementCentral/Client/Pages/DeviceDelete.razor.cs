using MachinesManagementCentral.Client.Services;
using MachinesManagementCentral.Shared.Domains;
using Microsoft.AspNetCore.Components;

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


        protected override void OnInitialized()
        {

            Device = DeviceDataService.GetDevice(int.Parse(DeviceId));

            base.OnInitialized();




        }

        protected void Delete(string DeviceId) 
        {
            DeviceDataService.DeleteDevice(int.Parse(DeviceId));
            NavigationManager.NavigateTo($"/DeviceLst");

        }

    }
}
