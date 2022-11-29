namespace EfPerfConsole.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EfPerfConsole.Models;
    using AutoBogus;
    using System.Data.Entity.Validation;

    internal sealed class Configuration : DbMigrationsConfiguration<EfPerfConsole.Models.EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EfPerfConsole.Models.EfDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //int idx = 0;
            //try
            //{
            //    for (idx = 0; idx < 5000; idx++)
            //    {
            //        Console.WriteLine(idx.ToString());
            //        var mockTenant = new AutoFaker<Tenant>()
            //            .RuleFor(f => f.Id, o => o.Random.Guid())
            //            .RuleFor(f => f.Name, o => o.Person.FullName)
            //            .RuleFor(f => f.Phone, o => o.Phone.PhoneNumber("##### #####"))
            //            .RuleFor(f => f.Email, o => o.Person.Email)
            //            .RuleFor(f => f.LogoBase64Str, o => o.Image.Abstract())
            //            .RuleFor(f => f.ContactPersonName, o => o.Person.FullName)
            //            .RuleFor(f => f.AddressLine1, o => o.Address.BuildingNumber())
            //            .RuleFor(f => f.Country, o => o.Address.Country())
            //            .RuleFor(f => f.PinCode, o => o.Address.ZipCode())
            //            .RuleFor(f => f.Disabled, o => o.Random.Bool())
            //            .RuleFor(f => f.CreatedBy, o => o.Person.FullName)
            //            .RuleFor(f => f.ModifiedBy, o => o.Person.FullName)
            //            .RuleFor(f => f.CreatedDate, o => o.Date.Recent(60))
            //            .RuleFor(f => f.ModifiedDate, o => o.Date.Recent(10))
            //            .Generate(1);

            //        var mockVenues = new AutoFaker<Venue>()
            //            .RuleFor(x => x.Id, o => o.Random.Guid())
            //            .RuleFor(x => x.Name, o => o.Company.CompanyName())
            //            .RuleFor(x => x.AddressLine1, o => o.Address.StreetAddress())
            //            .RuleFor(x => x.Country, o => o.Address.Country())
            //            .RuleFor(x => x.Pin, o => o.Address.ZipCode())
            //            .RuleFor(x => x.ContactNumber, o => o.Phone.PhoneNumber("##### #####"))
            //            .RuleFor(x => x.ContactPerson, o => o.Person.FullName)
            //            .RuleFor(x => x.ContactEmail, o => o.Person.Email)
            //            .RuleFor(x => x.Rating, o => o.Random.Int(0, 5))
            //            .RuleFor(x => x.Status, o => o.Random.Int(0, 5))
            //            .RuleFor(x => x.OpenOnWeekEnd, o => o.Random.Bool())
            //            .RuleFor(x => x.OpenOnPublicHolidays, o => o.Random.Bool())
            //            .RuleFor(f => f.CreatedBy, o => o.Person.FullName)
            //            .RuleFor(f => f.ModifiedBy, o => o.Person.FullName)
            //            .RuleFor(f => f.CreatedDate, o => o.Date.Recent(60))
            //            .RuleFor(f => f.ModifiedDate, o => o.Date.Recent(10))
            //            .RuleFor(f => f.Tenant, o => mockTenant.Single())
            //            .RuleFor(f => f.OpeningTime24h, o => o.Random.String(5))
            //            .RuleFor(f => f.ClosingTime24h, o => o.Random.String(5))
            //            .Generate(10);

            //        context.Tenants.AddOrUpdate(mockTenant.Single());
            //        context.Venues.AddRange(mockVenues);
                    
            //    }

            //    context.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    foreach (var error in ex.EntityValidationErrors)
            //        foreach (var str in error.ValidationErrors)
            //            Console.WriteLine($"{str.PropertyName}, {str.ErrorMessage}");

            //    throw;
            //}
        }
    }
}
