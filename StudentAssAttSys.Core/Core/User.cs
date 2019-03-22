using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Core.Core
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string FullName
        {
            get
            {
                return FirstName + ' ' + LastName;
            }
        }

        public virtual List<Module> Modules { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public virtual List<Assessment> Assessments { get; set; }
        public virtual List<Attendance> Attendances { get; set; }
    }
}
