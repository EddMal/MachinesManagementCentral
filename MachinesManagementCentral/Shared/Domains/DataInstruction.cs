using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesManagementCentral.Shared.Domains
{
    public class DataInstruction
    {
   
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Error length of data instruction, must be less than {1}")]
        public string? Instruction { get; set; } = string.Empty;
        
        public DateTime? Date { get; set; }

        //Ticks/ms more suitable form
        public TimeSpan? ExecutionTime { get {return DateTime.Now - Date;} } 

        public bool Executed { get; set; }


        [Required(ErrorMessage = "{0} Is required")]
        public int DeviceId { get; set; }

       
        public Device Device { get; set; }
    }
}
