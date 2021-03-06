// <auto-generated />
using FoodyAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodyAPI.Migrations
{
    [DbContext(typeof(APIContext))]
    [Migration("20210520132544_nextMigration")]
    partial class nextMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("FoodyAPI.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Userid")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("calories")
                        .HasColumnType("double");

                    b.Property<double>("carbs")
                        .HasColumnType("double");

                    b.Property<double>("fat")
                        .HasColumnType("double");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<double>("protein")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("Userid");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("FoodyAPI.Models.User", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("callories")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FoodyAPI.Models.Product", b =>
                {
                    b.HasOne("FoodyAPI.Models.User", null)
                        .WithMany("Favourite")
                        .HasForeignKey("Userid");
                });

            modelBuilder.Entity("FoodyAPI.Models.User", b =>
                {
                    b.Navigation("Favourite");
                });
#pragma warning restore 612, 618
        }
    }
}
