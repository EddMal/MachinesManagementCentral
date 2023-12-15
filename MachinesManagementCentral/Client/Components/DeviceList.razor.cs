using MachinesManagementCentral.Shared;
using MachinesManagementCentral.Shared.Domains;
namespace MachinesManagementCentral.Client.Components
{
    public partial class DeviceList
    {
        public List<Device> DevisteLst { get; set; } = new List<Device>();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            DevisteLst.Add(new Device() { DeviceId = Guid.NewGuid(),Location = Location.Sweden, Date =DateTime.Now, DeviceType ="CoffeeMakerx4000", Status = Status.offline });
            DevisteLst.Add(new Device() { DeviceId = Guid.NewGuid(), Location = Location.England, Date = DateTime.Now, DeviceType = "Saw", Status = Status.offline });

        }



    }
}
