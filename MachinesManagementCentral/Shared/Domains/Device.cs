using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesManagementCentral.Shared.Domains
{
    public enum Status { 
    Offline,
    Online
    }

    public enum Location
    {
        Sweden,
        England
    }

    public class Device
    {

        public int DeviceId { get; set; }

        //public Guid DeviceId { get; set; }
        [EnumDataType(typeof(Status), ErrorMessage = "{0} Must be selected.")]
        public Location Location { get; set; }
        public DateTime Date { get; set; }
        [StringLength(50, ErrorMessage = "Error length, must be between {2} and {1}", MinimumLength = 3)]
        public string DeviceType { get; set; } = string.Empty;

        [EnumDataType(typeof(Status), ErrorMessage = "{0} Must be selected.")]

        public List<DataInstruction>? DeviceDataInstructions { get; set; } = new List<DataInstruction>();


        public Status Status { get; set; }



    }
}
