using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SouthSea.Models;

namespace SouthSea.Migrations
{
    [DbContext(typeof(SouthSeaContext))]
    [Migration("20170627005015_UpdateMode")]
    partial class UpdateMode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SouthSea.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName");

                    b.Property<int>("PhoneNumber");

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SouthSea.Models.GemStone", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TypeStone");

                    b.HasKey("ID");

                    b.ToTable("GemStone");
                });

            modelBuilder.Entity("SouthSea.Models.Merchandise", b =>
                {
                    b.Property<int>("ID");

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<string>("ItemName")
                        .IsRequired();

                    b.Property<float>("Length");

                    b.Property<decimal>("Price");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<float>("Weight");

                    b.HasKey("ID");

                    b.ToTable("Merchandise");
                });

            modelBuilder.Entity("SouthSea.Models.Merchandise", b =>
                {
                    b.HasOne("SouthSea.Models.GemStone", "GemStones")
                        .WithOne("Merchandises")
                        .HasForeignKey("SouthSea.Models.Merchandise", "ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
