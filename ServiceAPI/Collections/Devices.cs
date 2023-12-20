using MachinesManagementCentral.Shared.Domains;

namespace DeviceAPI.Collections
{
    public class Devices
    {
        public static List<Device> DeviceList { get; set; } = new List<Device>() {

                new Device()
                {
                    DeviceId = 1,
                    Location = Location.Sweden,
                    Date = DateTime.Now,
                    DeviceType = "CoffeeMakerx4000",
                    Status = Status.Offline
                },

                new Device()
                {
                    DeviceId = 2,
                    Location = Location.England,
                    Date = DateTime.Now,
                    DeviceType = "Saw",
                    Status = Status.Online
                },

                new Device()
                {
                    DeviceId = 3,
                    Location = Location.Sweden,
                    Date = DateTime.Now,
                    DeviceType = "CoffeeMakerx4000",
                    Status = Status.Online
                },

                new Device()
                {
                    DeviceId = 4,
                    Location = Location.England,
                    Date = DateTime.Now,
                    DeviceType = "Saw",
                    Status = Status.Offline
                },

                new Device()
                {
                    DeviceId = 5,
                    Location = Location.England,
                    Date = DateTime.Now,
                    DeviceType = "Saw",
                    Status = Status.Offline
                }
            };
        }
}
