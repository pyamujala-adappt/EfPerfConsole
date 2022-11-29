using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPerfConsole.Models
{
    public class Tenant : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string Name
        { get; set; }

        [Required]
        public string LogoBase64Str
        { get; set; }

        [Required]
        [MaxLength(128)]
        public string ContactPersonName
        { get; set; }

        [Required]
        [Phone]
        [MaxLength(15)]
        public string Phone
        { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(128)]
        public string Email
        { get; set; }

        [Required]
        [MaxLength(128)]
        public string AddressLine1
        { get; set; }

        [MaxLength(128)]
        public string AddressLine2
        { get; set; }

        [MaxLength(128)]
        public string AddressLine3
        { get; set; }

        [MaxLength(128)]
        public string Landmark
        { get; set; }

        [MaxLength(128)]
        public string District
        { get; set; }

        [MaxLength(128)]
        public string State
        { get; set; }

        [Required]
        [MaxLength(128)]
        public string Country
        { get; set; }

        [Required]
        [MaxLength(10)]
        public string PinCode
        { get; set; }

        [Required]
        public bool Disabled
        { get; set; }

        public virtual ICollection<Venue> Venues 
        { get; set; }
    }
}
