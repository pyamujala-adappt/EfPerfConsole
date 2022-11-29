using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using EfPerfConsole.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPerfConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EF Parent-Child Relations");



            EfMethods methods = new EfMethods();

            //methods.LazyLoading();

            //methods.EagerLoading();

            //methods.ExplicitLoadWithFullChildData();

            //methods.GetChildCount();

            //methods.CheckChildExists();

            //methods.LoadSingleObjectFromObjectStateManager();

            //methods.LoadSingleObjectFromDatabase();

            //methods.QueryTables();

            //methods.QueryView();

            var result = BenchmarkRunner.Run<EfMethods>();


            Console.ReadLine();
        }
    }

    [MemoryDiagnoser]
    public class EfMethods
    {


        [Benchmark]
        public void LazyLoading()
        {
            Console.WriteLine("Demo 1: Lazy loading of related data");
            using (var content = new EfDbContext())
            {

                foreach (var row in content.Tenants.Take(10))
                    Console.WriteLine($"Display Name: {row.Name}, BadgesCnt: {row.Venues.Count}");
            }
        }

        [Benchmark]
        public void EagerLoading()
        {
            Console.WriteLine("Demo 2: Eager loading of related data");
            using (var content = new EfDbContext())
            {

                content.Configuration.LazyLoadingEnabled = false;
                foreach (var row in content.Tenants.Include("Venues").Take(10))
                    Console.WriteLine($"Display Name: {row.Name}, BadgesCnt: {row.Venues.Count}");
            }
        }
       

        [Benchmark]
        public void ExplicitLoadWithFullChildData()
        {
            Console.WriteLine("Demo 3: Explicit load of child data");
            using (var content = new EfDbContext())
            {

                content.Configuration.LazyLoadingEnabled = false;
                foreach (var row in content.Tenants.Take(10))
                {
                    content.Entry<Tenant>(row)
                        .Collection<Venue>(x => x.Venues)
                        .Query()
                        .Where(x => row.Name.StartsWith("John"))
                        .Load();

                    Console.WriteLine($"Display Name: {row.Name}, VenueCnt: {(row.Venues != null ? row.Venues.Count : 0)}");
                }
            }
        }

        [Benchmark]
        public void GetChildCount()
        {
            Console.WriteLine("Demo 4: Explicit loading of data for count");
            using (var content = new EfDbContext())
            {

                content.Configuration.LazyLoadingEnabled = false;
                foreach (var row in content.Tenants.Take(10))
                {
                    var cnt = content.Tenants.Where(t => t.Id == row.Id).SelectMany(x => x.Venues).Count();

                    Console.WriteLine($"Display Name: {row.Name}, VenueCnt: {cnt}");
                }
            }
        }

        [Benchmark]
        public void CheckChildExists()
        {
            Console.WriteLine("Demo 4: Explicit loading of data for count");
            using (var content = new EfDbContext())
            {

                content.Configuration.LazyLoadingEnabled = false;
                foreach (var row in content.Tenants.Take(10))
                {
                    var hasChild = content.Tenants.Where(t => t.Id == row.Id).SelectMany(x => x.Venues).Any();

                    Console.WriteLine($"Display Name: {row.Name}, Has Child: {hasChild}");
                }
            }
        }


        [Benchmark]
        public void QueryTables()
        {
            Console.WriteLine("Demo 5: Query data with joining the tables");
            using (var content = new EfDbContext())
            {

                var lst = content.Tenants.Take(10)
                    .GroupBy(p => new { p.Id, p.Name })
                    .SelectMany((c) => c.SelectMany(gp => gp.Venues)
                    .Select(y => new { VenueId = y.Id, VenueName = y.Name, y.Country, y.Status, y.ContactPerson, y.ContactNumber, c.Key.Id, c.Key.Name }));

                foreach (var r in lst)
                    Console.WriteLine($"{r.Id} | {r.Name} | {r.VenueId} | {r.VenueName} | {r.Country} | {r.Status} | {r.ContactPerson} | {r.ContactNumber}");
            }
        }


        [Benchmark]
        public void QueryView()
        {
            Console.WriteLine("Demo 6: Query data with Views");
            using (var content = new EfDbContext())
            {

                var lst = content.TenantVenues.Take(10).ToList();
                foreach (var r in lst)
                    Console.WriteLine($"{r.Id} | {r.Name} | {r.VenueId} | {r.VenueName} | {r.Country} | {r.Status} | {r.ContactPerson} | {r.ContactNumber}");
            }
        }

        [Benchmark]
        public void LoadSingleObjectFromObjectStateManager()
        {
            Console.WriteLine("Demo 6: Fetch from ObjectStateManager");
            using (var content = new EfDbContext())
            {

                var d = content.Tenants.OrderBy(x => x.Id).Take(10).ToList();
         
                var t = content.Tenants.Find(Guid.Parse("A46E5CBD-23B5-5045-EE45-00151B1AA8CD"));
                Console.WriteLine(t.Name);
            }
        }

        [Benchmark]
        public void LoadSingleObjectFromDatabase()
        {
            Console.WriteLine("Demo 6: Fetch from Database");
            using (var content = new EfDbContext())
            {

                var d = content.Tenants.OrderBy(x => x.Id).Take(10).ToList();

                var g = Guid.Parse("A46E5CBD-23B5-5045-EE45-00151B1AA8CD");
                var t = content.Tenants.Where(x => x.Id == g).Single();
                Console.WriteLine(t.Name);
            }
        }
    }
}
