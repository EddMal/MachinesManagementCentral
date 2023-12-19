using MachinesManagementCentral.Client.Services;
using Microsoft.AspNetCore.Components;

namespace MachinesManagementCentral.Client.Components
{
    public partial class DailyStats
    {

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }

        public int NumberOfDevices { get; set; }


        protected override void OnInitialized()
        {
            NumberOfDevices = DeviceDataService.GetDevices().Count;
            
            base.OnInitialized();
        }

    }
}
