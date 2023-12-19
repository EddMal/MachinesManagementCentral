using MachinesManagementCentral.Client.Services;
using MachinesManagementCentral.Shared.Domains;
using Microsoft.AspNetCore.Components;

namespace MachinesManagementCentral.Client.Pages
{
    public partial class SendInstruction
    {
        [Parameter]
        public string? DeviceId { get; set; }

        public DataInstruction Datanstruction { get; set; } = new DataInstruction();

        public List<DataInstruction> Datanstructions { get; set; } = new List<DataInstruction>();

        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Device Device { get; set; } = new Device();


        protected override void OnInitialized()
        {
            //Insert control if valid (deviceId)
            Device = DeviceDataService.GetDevice(int.Parse(DeviceId));

            base.OnInitialized();

        }

        protected async Task HandleValidSubmit()
        {

            //Error handling/control
            if (Device != null)
            {
                var latestInstruction = DeviceDataService.DeviceLatestDataInstructionStatus(Device.DeviceId);
                if (latestInstruction.Executed != false)
                {
                    DeviceDataService.SendDataInstruction(Datanstruction);
                    NavigationManager.NavigateTo($"/DeviceLst");
                }

                
            }

        }

    }
}

