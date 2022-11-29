using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPerfConsole.Models
{
    public class BaseEntity
    {
        [Required]
        public Guid Id
        { get; set; }

        [Required]
        public string CreatedBy
        { get; set; }

        [Required]
        public DateTime CreatedDate
        { get; set; }

        [Required]
        public string ModifiedBy
        { get; set; }

        [Required]
        public DateTime ModifiedDate
        { get; set; }
    }
}
