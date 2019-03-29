using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Core.Core
{
    public class Assessment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateTimeStart { get; set; }
        [Required]
        public DateTime DateTimeEnd { get; set; }
        [Required]
        [ForeignKey("Lecturer")]
        public string LecturerId { get; set; }
        [Required]
        [ForeignKey("Module")]
        public int ModuleId { get; set; }


        public virtual Module Module { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
