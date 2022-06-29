using Foody.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace DALn
{
    public class Context : DbContext
    {
        private string connectionString;

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }


        public Context(DbContextOptions<Context> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(c => c.Favourite)
                .WithOne(e => e.User);

            modelBuilder.Entity<User>()
                .HasMany(c => c.Statistics)
                .WithOne(e => e.User);

        }
    }



    class FoodyContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[]? args = null)
        {

            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseMySql(
            "server=sql103.epizy.com;" +
            "user=epiz_31484356;" +
            "password=foodyme123;" +
            "database=epiz_31484356_foody;",
            new MySqlServerVersion(new Version(8, 0, 11))
            );

            return new Context(optionsBuilder.Options);
        }
    }
}
