using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudentAssAttSys.Core.Core
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0,100)]
        public double GPAPercentage { get; set; }
    
        public virtual ICollection<Lecturer> Lecturers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Assessment> Assessments { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }

    }
}
