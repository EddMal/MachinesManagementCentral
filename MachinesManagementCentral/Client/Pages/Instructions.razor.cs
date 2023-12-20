using MachinesManagementCentral.Client.Services;
using MachinesManagementCentral.Shared.Domains;
using Microsoft.AspNetCore.Components;

namespace MachinesManagementCentral.Client.Pages
{
    public partial class Instructions
    {
        [Parameter]
        public string? DeviceId { get; set; }

        public DataInstruction Datanstruction { get; set; } = new DataInstruction();

        public List<DataInstruction> Datanstructions { get; set; } = new List<DataInstruction>();

        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }

        public Device Device { get; set; } = new Device();


        protected override void OnInitialized()
        {
            if (DeviceDataService.GetDevice(int.Parse(DeviceId)) == null || DeviceId == "0")
            {
                Datanstructions = DeviceDataService.GetDevicesDataInstructions();
            }
            else 
            {
                Datanstructions = DeviceDataService.GetDeviceDataInstructions(int.Parse(DeviceId));
            }
            
            base.OnInitialized();

        }

        protected async Task RefreshDeviceInstructions()
        {

            Datanstructions = DeviceDataService.GetDeviceDataInstructions(int.Parse(DeviceId));

        }

        protected async Task RefreshAllInstructions()
        {
            Datanstructions = DeviceDataService.GetDevicesDataInstructions();

        }

    }
}

