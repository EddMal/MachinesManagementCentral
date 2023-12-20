using MachinesManagementCentral.Client.Services;
using MachinesManagementCentral.Shared.Domains;
using Microsoft.AspNetCore.Components;

namespace MachinesManagementCentral.Client.Pages
{
    public partial class SendInstruction
    {
        [Parameter]
        public string? DeviceId { get; set; }

        public DataInstruction DataInstruction { get; set; } = new DataInstruction();

        public DataInstruction latestInstructionTest { get; set; } = new DataInstruction();

        public string DataInstructionMsg { get; set; } = string.Empty;

        public List<DataInstruction> DatanInstructions { get; set; } = new List<DataInstruction>();

        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Device Device { get; set; } = new Device();


        protected override void OnInitialized()
        {

            Device = DeviceDataService.GetDevice(int.Parse(DeviceId));
            latestInstructionTest = DeviceDataService.DeviceLatestDataInstructionStatus(int.Parse(DeviceId));

            base.OnInitialized();

        }

        protected async Task HandleValidSubmit()
        {

            //Error handling/control
            if (Device != null)
            {
               
                var latestInstruction = DeviceDataService.DeviceLatestDataInstructionStatus(Device.DeviceId);
                if (latestInstruction.Executed == true)
                {
                    var DataInstruction = new DataInstruction()
                    {
                        DeviceId = int.Parse(DeviceId),
                        Instruction = DataInstructionMsg,
                    };

                    DeviceDataService.SendDataInstruction(DataInstruction);
                }

                NavigationManager.NavigateTo($"/DeviceLst");

            }

        }

        protected async Task HandleInValidSubmit()
        {
            throw new Exception($"{DataInstruction}");
           

        }

    }
}

