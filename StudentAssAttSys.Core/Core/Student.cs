using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Core.Core
{
    public class Student
    {
        [ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }
        [Required]
        public string StudentNumber { get; set; }
        
    }
}
