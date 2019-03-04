using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssAttSys.Core.Core
{
    public class Result
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Assessment")]
        public int AssessmentId { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Student")]
        public string StudentId { get; set; }

        [Required]
        [Range(0, 100)]
        public uint Mark { get; set; }

        public virtual Assessment Assessment { get; set; }
        public virtual Student Student { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
