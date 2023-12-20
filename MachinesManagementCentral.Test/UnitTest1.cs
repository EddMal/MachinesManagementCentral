using MachinesManagementCentral.Client.Services;

namespace MachinesManagementCentral.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Dataservice_Test_Instruction_services()
            {
                DeviceDataService deviceDataService = new DeviceDataService();

                var instruction = deviceDataService.DeviceLatestDataInstructionStatus(1);

                Assert.True(instruction.Executed);

            }

    }
}
