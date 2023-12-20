using MachinesManagementCentral.Client.Services;
using MachinesManagementCentral.Shared.Domains;
using Microsoft.AspNetCore.Components;

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


        protected override void OnInitialized()
        {
    
            Device = DeviceDataService.GetDevice(int.Parse(DeviceId));

           
            base.OnInitialized();

        }

    }
}
