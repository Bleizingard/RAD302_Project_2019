using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Core.Core
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateTimeLectureStart { get; set; }
        [Required]
        public DateTime DateTimeLectureEnd { get; set; }
        public DateTime DateTimeAttendanceStart { get; set; }
        public DateTime DateTimeAttendanceEnd { get; set; }
        [Required]
        public int LecturerId { get; set; }
        [Required]
        public int ModuleId { get; set; } 

        public virtual Lecturer Lecturer { get; set; }
        public virtual Module Module { get; set; }
        public virtual List<Student> PresentStudents { get; set; }
    }
}
