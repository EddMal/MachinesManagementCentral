using MachinesManagementCentral.Client.Components;
using MachinesManagementCentral.Client.Pages;
using MachinesManagementCentral.Shared.Domains;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            DevicesDataInstructions.Add(new DataInstruction()
            {
                Id = 1,
                DeviceId = 1,
                Date = DateTime.Now,
                Executed = true,
                //ExecutionTime = 0,
                Instruction = "When(sawing > 100){Stop;}",
                Device = Devices[0]

            });;
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
            updatedDevice.DeviceDataInstructions = DevicesDataInstructions.Where(x => x.DeviceId == updatedDevice.DeviceId).ToList();
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
            UpdateInstructions(DevicesDataInstructions);
            return DevicesDataInstructions;
        }

        public List<DataInstruction> GetDeviceDataInstructions(int deviceId)
        {
            var dataInstructions = DevicesDataInstructions.Where(x => x.DeviceId == deviceId).ToList();
            return UpdateInstructions(dataInstructions);
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
                    var exec = rnd.Next(1, 10);
                    //Simulates if instruction executed or not.
                    if (exec > 3)
                    {
                        instruction.Executed = true;
                        instruction.ExecutionTime = DateTime.Now - instruction.Date;
                        var InstructionReplacementList = new List<DataInstruction>();
                        foreach (var deviceinstruction in DevicesDataInstructions)
                        {
                            if (deviceinstruction.Id == instruction.Id)
                            {
                                deviceinstruction.Executed = instruction.Executed;
                                deviceinstruction.ExecutionTime = instruction.ExecutionTime;
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
            var exec = rnd.Next(1, 10);
            //Simulates if instruction executed or not.
            if (exec < 3)
                DataInstruction.Executed = false;
            else
            { 
                DataInstruction.Executed = true;
                DataInstruction.ExecutionTime = DateTime.Now - DataInstruction.Date;
            }

            Random rndm = new Random();
            DataInstruction.Id = rndm.Next(100000);

            var device = Devices.FirstOrDefault(x => x.DeviceId == DataInstruction.DeviceId);
            DataInstruction.Device = device;
            DevicesDataInstructions.Add(DataInstruction);
            Devices[device.DeviceId].DeviceDataInstructions.Add(DataInstruction);
        }

        private void UpdateAllInstructions()
        {
            foreach (var instruction in DevicesDataInstructions)
            {
                if (instruction != null)
                {
                    //Simulates if instruction executed or not.
                    if (instruction.Executed == false)
                    {
                        Random rnd = new Random();
                        var exec = rnd.Next(1, 10);
                        //Simulates if instruction executed or not.
                        if (exec > 3)
                        {
                            instruction.Executed = true;
                            instruction.ExecutionTime = DateTime.Now - instruction.Date;
                            var InstructionReplacementList = new List<DataInstruction>();
                            foreach (var deviceinstruction in DevicesDataInstructions)
                            {
                                if (deviceinstruction.Id == instruction.Id)
                                {
                                    deviceinstruction.Executed = instruction.Executed;
                                    deviceinstruction.ExecutionTime = instruction.ExecutionTime;
                                }

                                InstructionReplacementList.Add(deviceinstruction);

                            }
                            DevicesDataInstructions = InstructionReplacementList;
                        }
                    }
                }
            }
        }

        private List<DataInstruction> UpdateInstructions(List<DataInstruction> DataInstructions)
        {
            foreach (var datanIstruction in DataInstructions)
            {
                if (datanIstruction != null)
                {
                    //Simulates if instruction executed or not.
                    if (datanIstruction.Executed == false)
                    {
                        Random rnd = new Random();
                        var exec = rnd.Next(1, 10);
                        //Simulates if instruction executed or not.
                        if (exec > 3)
                        {
                            datanIstruction.Executed = true;
                            datanIstruction.ExecutionTime = DateTime.Now - datanIstruction.Date;
                            var InstructionReplacementList = new List<DataInstruction>();
                            foreach (var deviceinstruction in DevicesDataInstructions)
                            {
                                if (deviceinstruction.Id == datanIstruction.Id)
                                {
                                    deviceinstruction.Executed = datanIstruction.Executed;
                                    deviceinstruction.ExecutionTime = datanIstruction.ExecutionTime;
                                }

                                InstructionReplacementList.Add(deviceinstruction);

                            }
                            DevicesDataInstructions = InstructionReplacementList;
                        }
                    }
                }

            }
            return DataInstructions;
        }
    }
}