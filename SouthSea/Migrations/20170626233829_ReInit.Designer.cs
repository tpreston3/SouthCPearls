using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SouthSea.Models;

namespace SouthSea.Migrations
{
    [DbContext(typeof(SouthSeaContext))]
    [Migration("20170626233829_ReInit")]
    partial class ReInit
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
                    b.Property<int>("ID");

                    b.Property<string>("TypeStone");

                    b.HasKey("ID");

                    b.ToTable("GemStone");
                });

            modelBuilder.Entity("SouthSea.Models.Merchandise", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<string>("ItemName")
                        .IsRequired();

                    b.Property<int>("Length");

                    b.Property<decimal>("Price");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<int>("Weight");

                    b.HasKey("ID");

                    b.ToTable("Merchandise");
                });

            modelBuilder.Entity("SouthSea.Models.GemStone", b =>
                {
                    b.HasOne("SouthSea.Models.Merchandise", "Merchandises")
                        .WithOne("GemStones")
                        .HasForeignKey("SouthSea.Models.GemStone", "ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
