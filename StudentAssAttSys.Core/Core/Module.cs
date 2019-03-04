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
        [Required]
        public string Name { get; set; }
    }
}
