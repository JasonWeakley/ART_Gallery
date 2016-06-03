using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ART_Gallery.Models
{
    public class ArtGalleryContext : DbContext
    {
        // as a personal naming convention, 
        // name the DbSets with either "DbSet" or "DbContext" appended to the variable name
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> ProductDbSet { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<Event> Event { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // this incorporates the tables you need
            // can configure more than this but could do everything you want in LINQ
            modelBuilder.Entity<Employee>()
                .ToTable("Employee")
                .HasKey(c => c.EmployeeId);

            // The aqua colored Customer inside <> is modeling the table in the database
            // it refers to the Model called Customer in the Model folder
            modelBuilder.Entity<Customer>()
                // the red is referring to the actual table in the DB
                .ToTable("Customer")
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Product>()
                .ToTable("Product")
                .HasKey(c => c.ProductId);

            modelBuilder.Entity<Gallery>()
               .ToTable("Gallery")
               .HasKey(c => c.GalleryId);

            modelBuilder.Entity<Event>()
               .ToTable("Event")
               .HasKey(c => c.EventId);

        }
    }
}