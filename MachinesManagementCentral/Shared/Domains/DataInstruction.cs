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
        [Required(ErrorMessage = "{0} Is required")]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Error length of data instruction, must be less than {1}")]
        public string? Instruction { get; set; } = string.Empty;
        [Required]
        public DateTime? Date { get; set; }

        //Ticks/ms more suitable form
        public TimeSpan? ExecutionTime { get {return DateTime.Now - Date;} } 
        [Required]
        public bool Executed { get; set; }


        [Required(ErrorMessage = "{0} Is required")]
        public int DeviceId { get; set; }

        [Required]
        public Device Device { get; set; }
    }
}
