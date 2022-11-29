using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;

namespace EfPerfConsole.Models
{
    public partial class EfDbContext : DbContext
    {
        public EfDbContext()
            : base("default")
        {
            Database.SetInitializer<EfDbContext>(null);
            //base.Configuration.LazyLoadingEnabled = true;
            //base.Configuration.ProxyCreationEnabled = false;            
        }

        public DbSet<Venue> Venues
        { get; set; }

        public DbSet<Tenant> Tenants
        { get; set; }

        public DbSet<TenantVenues> TenantVenues
        { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenantVenues>().ToTable("vw_tenant_venues").HasKey(x => new { x.Id, x.VenueId });                        
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(DbModelBuilder modelBuilder);
    }
}