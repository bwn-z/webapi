using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Npgsql;

namespace WebApiQuest.Models
{
    public class AppDbContext:DbContext
    {


        public AppDbContext():base(nameOrConnectionString: "myContext")
        {
            
        }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SizeTable> SizeTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<Purchase>().ToTable("Purchases", "public");
            modelBuilder.Entity<Product>().ToTable("Products", "public");
            modelBuilder.Entity<SizeTable>().ToTable("SizeTables", "public");

            base.OnModelCreating(modelBuilder);
        }
    }

    //class NpgSqlConfiguration : DbConfiguration
    //{
    //    public NpgSqlConfiguration()
    //    {
    //        var name = "Npgsql";

    //        SetProviderFactory(providerInvariantName: name,
    //            providerFactory: NpgsqlFactory.Instance);

    //        SetProviderServices(providerInvariantName: name,
    //            provider: NpgsqlServices.Instance);

    //        SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());
    //    }
    //}
}