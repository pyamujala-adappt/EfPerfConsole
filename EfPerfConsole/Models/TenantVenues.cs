using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPerfConsole.Models
{
    [Table("vw_tenant_venues")]
    public class TenantVenues
    {
        public Guid Id
        { get; set; }

        public string Name
        { get; set; }

        public Guid VenueId
        { get; set; }

        public string VenueName
        { get; set; }

        public string Country
        { get; set; }

        public int Status
        { get; set; }

        public string ContactPerson
        { get; set; }

        public string ContactNumber
        { get; set; }
    }
}
