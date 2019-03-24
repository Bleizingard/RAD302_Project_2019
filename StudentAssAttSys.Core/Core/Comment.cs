using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAssAttSys.Core.Core
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime DateTimeCreation { get; set; }
        [ForeignKey("Result")]
        [Column(Order = 0)]
        public int AssessmentId { get; set; }
        [ForeignKey("Result")]
        [Column(Order = 1)]
        public string StudentId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual Result Result { get; set; }
        public virtual User User { get; set; }

    }
}