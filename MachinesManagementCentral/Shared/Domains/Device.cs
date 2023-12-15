using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesManagementCentral.Shared.Domains
{
    public enum Status { 
    offline,
    online
    }

    public enum Location
    {
        Sweden,
        England
    }

    public class Device
    {

        public Guid DeviceId { get; set; }
        public Location Location { get; set; }
        public DateTime Date { get; set; }
        public string DeviceType { get; set; } = string.Empty;

        public Status Status { get; set; }



    }
}
