using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Core.Core
{
    public class Lecturer
    {
        [ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }
        public virtual List<Module> Modules { get; set; }
        public virtual List<Assessment> Assessments { get; set; }
    }
}
