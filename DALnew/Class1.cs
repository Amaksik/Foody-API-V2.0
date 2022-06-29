using System;

namespace DALnew
{
    public class Class1 : DbContext
    {
        private string connectionString;

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<DayIntake> DayIntakes { get; set; }


        public APIContext(DbContextOptions<APIContext> options)
        : base(options)
        {
        }

        //public APIContext()
        //{
        //}

        //public APIContext()
        //{
        //    //connectionString = configurationConnectionString;
        //    Database.EnsureCreated();
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    /*
        //    optionsBuilder.UseMySql(
        //        "server=foodydb.cxa6afpccjzk.us-east-2.rds.amazonaws.com;" +
        //        "user=admin;" +
        //        "password=MyFoodyDB123;" +
        //        "database=foodydb;",
        //        new MySqlServerVersion(new Version(8, 0, 11))
        //    );
        //    */
        //    optionsBuilder.UseMySql(
        //        "server=sql11.freemysqlhosting.net;" +
        //        "user=sql11498693;" +
        //        "password=ehEr9WFBFW;" +
        //        "database=sql11498693;", 
        //        new MySqlServerVersion(new Version(8, 0, 11))
        //        );


        //// using configuraion
        ///*
        //optionsBuilder.UseMySql(
        //    "server=sql103.epizy.com;" +
        //    "user=epiz_31484356;" +
        //    "password=foodyme123;" +
        //    "database=epiz_31484356_foody;",
        //    new MySqlServerVersion(new Version(8, 0, 11))
        //    );
        //*/

        //}


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .HasMany(c => c.Favourite)
        //        .WithOne(e => e.User);

        //    modelBuilder.Entity<User>()
        //        .HasMany(c => c.Statistics)
        //        .WithOne(e => e.User);

        //    modelBuilder.Entity<DayIntake>()
        //        .HasOne(e => e.User)
        //        .WithMany(c => c.Statistics);

        //}
    }
}
