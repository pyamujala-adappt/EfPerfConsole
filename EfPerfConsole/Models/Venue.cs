using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPerfConsole.Models
{
    public class Venue : BaseEntity
    {
        [Required]
        [MaxLength(length: 256, ErrorMessage = "Venue name cannot be more than 256 characters")]
        public string Name
        { get; set; }

        [MaxLength(length: 1024, ErrorMessage = "Venue description cannot be more than 1024 characters")]
        public string Description
        { get; set; }

        [Required]
        [MaxLength(length: 256, ErrorMessage = "Venue address line 1 cannot be more than 256 characters")]
        public string AddressLine1
        { get; set; }

        [MaxLength(length: 256, ErrorMessage = "Venue address line 2 cannot be more than 256 characters")]
        public string AddressLine2
        { get; set; }

        [MaxLength(length: 256, ErrorMessage = "Venue address line 3 cannot be more than 256 characters")]
        public string AddressLine3
        { get; set; }

        [MaxLength(length: 256, ErrorMessage = "Landmark cannot be more than 256 characters")]
        public string Landmark
        { get; set; }

        [MaxLength(length: 256, ErrorMessage = "Venue's state cannot be more than 256 characters")]
        public string State
        { get; set; }

        [Required]
        [MaxLength(length: 256, ErrorMessage = "Venue's country cannot be more than 256 characters")]
        public string Country
        { get; set; }

        [Required]
        [MaxLength(length: 10, ErrorMessage = "Venue's PIN cannot be more than 10 characters")]
        public string Pin
        { get; set; }

        [Required]
        [MaxLength(length: 15, ErrorMessage = "Contact number cannot be more than 15 characters")]
        [Phone]
        public string ContactNumber
        { get; set; }

        [Required]
        [MaxLength(length: 256, ErrorMessage = "Contact person name cannot be more than 256 characters")]
        public string ContactPerson
        { get; set; }

        [MaxLength(length: 256, ErrorMessage = "Contact email cannot be more than 256 characters")]
        [EmailAddress]
        public string ContactEmail
        { get; set; }

        [MaxLength(length: 256, ErrorMessage = "Geo code cannot be more than 256 characters")]
        public string GeoCode
        { get; set; }

        public decimal Rating
        { get; set; }

        [MaxLength(length: 5, ErrorMessage = "Opening time cannot be more than 5 characters")]
        public string OpeningTime24h
        { get; set; }

        [MaxLength(length: 5, ErrorMessage = "Closing time cannot be more than 5 characters")]
        public string ClosingTime24h
        { get; set; }

        [Required]
        public int Status
        { get; set; }

        public bool OpenOnWeekEnd
        { get; set; }

        public bool OpenOnPublicHolidays
        { get; set; }

        [Required]
        public Tenant Tenant
        { get; set; }
    }
}
