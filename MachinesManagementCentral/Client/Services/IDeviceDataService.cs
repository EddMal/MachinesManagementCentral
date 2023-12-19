using MachinesManagementCentral.Shared.Domains;
namespace MachinesManagementCentral.Client.Services
{
    public interface IDeviceDataService
    {

        List<Device> GetDevices();

        List<DataInstruction> GetDevicesDataInstructions();

        List<DataInstruction> GetDeviceDataInstructions(int deviceId);

        DataInstruction DeviceLatestDataInstructionStatus(int deviceId);

        void SendDataInstruction(DataInstruction DataInstruction);


        Device GetDevice(int id);

        void DeleteDevice(int id);

        void UpdateDevice(Device device);

        void AddDevice(Device device);

    }
}
