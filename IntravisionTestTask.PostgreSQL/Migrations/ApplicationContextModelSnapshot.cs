﻿// <auto-generated />
using System;
using IntravisionTestTask.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IntravisionTestTask.PostgreSQL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IntravisionTestTask.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ProductSlotId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ProductTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductSlotId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("IntravisionTestTask.Domain.Entities.ProductMachine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ProductMachines");
                });

            modelBuilder.Entity("IntravisionTestTask.Domain.Entities.ProductSlot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("ProductMachineId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductMachineId");

                    b.ToTable("ProductSlots");
                });

            modelBuilder.Entity("IntravisionTestTask.Domain.Entities.ProductType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("IntravisionTestTask.Domain.Entities.Product", b =>
                {
                    b.HasOne("IntravisionTestTask.Domain.Entities.ProductSlot", "ProductSlot")
                        .WithMany("Products")
                        .HasForeignKey("ProductSlotId");

                    b.HasOne("IntravisionTestTask.Domain.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId");

                    b.Navigation("ProductSlot");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("IntravisionTestTask.Domain.Entities.ProductSlot", b =>
                {
                    b.HasOne("IntravisionTestTask.Domain.Entities.ProductMachine", "ProductMachine")
                        .WithMany("ProductSlots")
                        .HasForeignKey("ProductMachineId");

                    b.Navigation("ProductMachine");
                });

            modelBuilder.Entity("IntravisionTestTask.Domain.Entities.ProductMachine", b =>
                {
                    b.Navigation("ProductSlots");
                });

            modelBuilder.Entity("IntravisionTestTask.Domain.Entities.ProductSlot", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
