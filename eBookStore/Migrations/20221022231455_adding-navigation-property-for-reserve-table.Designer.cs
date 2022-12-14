// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace eBookStore.Migrations
{
    [DbContext(typeof(BookDbContext))]
    [Migration("20221022231455_adding-navigation-property-for-reserve-table")]
    partial class addingnavigationpropertyforreservetable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("eBookStore.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BookingNumber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Reserve")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("eBookStore.Models.Reserve", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookingNumber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReservedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Reserves");
                });

            modelBuilder.Entity("eBookStore.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ReserveId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReserveId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("eBookStore.Models.Reserve", b =>
                {
                    b.HasOne("eBookStore.Models.Book", null)
                        .WithMany("ReserveDetails")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eBookStore.Models.User", b =>
                {
                    b.HasOne("eBookStore.Models.Reserve", null)
                        .WithMany("Users")
                        .HasForeignKey("ReserveId");
                });

            modelBuilder.Entity("eBookStore.Models.Book", b =>
                {
                    b.Navigation("ReserveDetails");
                });

            modelBuilder.Entity("eBookStore.Models.Reserve", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
