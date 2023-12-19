using MachinesManagementCentral.Client.Components;
using MachinesManagementCentral.Client.Pages;
using MachinesManagementCentral.Shared.Domains;

namespace MachinesManagementCentral.Client.Services
{
    public class DeviceDataService : IDeviceDataService
    {
        public List<Device> Devices { get; set; } = new List<Device>();

        public List<DataInstruction> DevicesDataInstructions { get; set; } = new List<DataInstruction>();

        public DeviceDataService()
        {
            Devices.Add(new Device()
            {
                DeviceId = 1,
                Location = Location.Sweden,
                Date = DateTime.Now,
                DeviceType = "CoffeeMakerx4000",
                Status = Status.Offline
            });

            Devices.Add(new Device()
            {
                DeviceId = 2,
                Location = Location.England,
                Date = DateTime.Now,
                DeviceType = "Saw",
                Status = Status.Online
            });

            Devices.Add(new Device()
            {
                DeviceId = 3,
                Location = Location.Sweden,
                Date = DateTime.Now,
                DeviceType = "CoffeeMakerx4000",
                Status = Status.Online
            });

            Devices.Add(new Device()
            {
                DeviceId = 4,
                Location = Location.England,
                Date = DateTime.Now,
                DeviceType = "Saw",
                Status = Status.Offline
            });

            Devices.Add(new Device()
            {
                DeviceId = 5,
                Location = Location.England,
                Date = DateTime.Now,
                DeviceType = "Saw",
                Status = Status.Offline
            });
        }
        public List<Device> GetDevices()
        {
            return Devices;
        }

        public Device GetDevice(int Id)
        {
            return Devices.FirstOrDefault(x => x.DeviceId == Id);
        }

        public void DeleteDevice(int Id)
        {
            var Device = Devices.FirstOrDefault(x => x.DeviceId == Id);
            if (Device != null)
            {
                Devices.Remove(Device);
            }
        }

        public void UpdateDevice(Device updatedDevice)
        {
            var device = Devices.FirstOrDefault(d => d.DeviceId == updatedDevice.DeviceId);
            updatedDevice.DeviceDataInstructions = DevicesDataInstructions.Where(x=>x.DeviceId == updatedDevice.DeviceId).ToList();
            if (device != null)
            {
                device.Location = updatedDevice.Location;
                device.Date = updatedDevice.Date;
                device.DeviceType = updatedDevice.DeviceType;
                device.Status = updatedDevice.Status;
                device.DeviceDataInstructions = updatedDevice.DeviceDataInstructions;
            }
        }

        public void AddDevice(Device device)
        {
            Random rnd = new Random();
            device.DeviceId = rnd.Next(100000);
            Devices.Add(device);
        }

        public List<DataInstruction> GetDevicesDataInstructions()
        {
            return DevicesDataInstructions;
        }

        public List<DataInstruction> GetDeviceDataInstructions(int deviceId)
        {
            return DevicesDataInstructions.Where(x => x.DeviceId == deviceId).ToList();
        }

        public DataInstruction DeviceLatestDataInstructionStatus(int deviceId)
        {
            var instruction = DevicesDataInstructions.Where(x => x.DeviceId == deviceId).OrderByDescending(x => x.Date).FirstOrDefault();
            if (instruction != null)
            {
                //Simulates if instruction executed or not.
                if (instruction.Executed == false)
                {
                    Random rnd = new Random();
                    var exec = rnd.Next(1, 2);
                    //Simulates if instruction executed or not.
                    if (exec == 2)
                    {
                        instruction.Executed = true;
                        var InstructionReplacementList = new List<DataInstruction>();
                        foreach (var deviceinstruction in DevicesDataInstructions)
                        {
                            if (deviceinstruction.Id == instruction.Id)
                            {
                                deviceinstruction.Executed = instruction.Executed;
                            }

                            InstructionReplacementList.Add(deviceinstruction);

                        }
                        DevicesDataInstructions = InstructionReplacementList;
                    }
                }

                

            }
            return instruction;
        }

        //public void UpdateDataInstruction(int UpdatedinstructionID)
        //{
        //    var dataInstruction = DevicesDataInstructions.FirstOrDefault(d => d.Id == updatedDeviceId);
        //    if (device != null)
        //    {
        //        device.Location = updatedDevice.Location;
        //        device.Date = updatedDevice.Date;
        //        device.DeviceType = updatedDevice.DeviceType;
        //        device.Status = updatedDevice.Status;
        //    }
        //}

        public void SendDataInstruction(DataInstruction DataInstruction)
        {
            Random rnd = new Random();
            var exec = rnd.Next(1,2);
            //Simulates if instruction executed or not.
            if(exec == 1)
                DataInstruction.Executed = false;
            else
                DataInstruction.Executed = true;

            var device = Devices.FirstOrDefault(x => x.DeviceId == DataInstruction.DeviceId);
            DataInstruction.Device = device;
             DevicesDataInstructions.Add(DataInstruction);
        }
    }
}