namespace EfPerfConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tenants",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        LogoBase64Str = c.String(nullable: false),
                        ContactPersonName = c.String(nullable: false, maxLength: 128),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 128),
                        AddressLine1 = c.String(nullable: false, maxLength: 128),
                        AddressLine2 = c.String(maxLength: 128),
                        AddressLine3 = c.String(maxLength: 128),
                        Landmark = c.String(maxLength: 128),
                        District = c.String(maxLength: 128),
                        State = c.String(maxLength: 128),
                        Country = c.String(nullable: false, maxLength: 128),
                        PinCode = c.String(nullable: false, maxLength: 10),
                        Disabled = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        AddressLine1 = c.String(nullable: false, maxLength: 256),
                        AddressLine2 = c.String(maxLength: 256),
                        AddressLine3 = c.String(maxLength: 256),
                        Landmark = c.String(maxLength: 256),
                        State = c.String(maxLength: 256),
                        Country = c.String(nullable: false, maxLength: 256),
                        Pin = c.String(nullable: false, maxLength: 10),
                        ContactNumber = c.String(nullable: false, maxLength: 15),
                        ContactPerson = c.String(nullable: false, maxLength: 256),
                        ContactEmail = c.String(maxLength: 256),
                        GeoCode = c.String(maxLength: 256),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OpeningTime24h = c.String(maxLength: 5),
                        ClosingTime24h = c.String(maxLength: 5),
                        Status = c.Int(nullable: false),
                        OpenOnWeekEnd = c.Boolean(nullable: false),
                        OpenOnPublicHolidays = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Tenant_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tenants", t => t.Tenant_Id, cascadeDelete: true)
                .Index(t => t.Tenant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venues", "Tenant_Id", "dbo.Tenants");
            DropIndex("dbo.Venues", new[] { "Tenant_Id" });
            DropTable("dbo.Venues");
            DropTable("dbo.Tenants");
        }
    }
}
