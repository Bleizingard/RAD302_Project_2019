using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Core.Core
{
    public class Student : User
    {
        [Required]
        public string StudentNumber { get; set; }
        [Required]
        [ForeignKey("Class")]
        public int ClassId { get; set; }

        public virtual List<Module> Modules { get; set; }
        public virtual ClassGroup Class { get; set; }
    }
}
