﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Database.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220114080505_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Domain.Entities.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacilityStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2)
                        .HasColumnName("StatusId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("FacilityStatusId");

                    b.ToTable("Facility");
                });

            modelBuilder.Entity("Domain.Entities.FacilityStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FacilityStatus");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "InActive"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Active"
                        },
                        new
                        {
                            Id = 3,
                            Name = "OnHold"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<int?>("FacilityId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("Domain.Entities.Facility", b =>
                {
                    b.HasOne("Domain.Entities.FacilityStatus", "FacilityStatus")
                        .WithMany("Facility")
                        .HasForeignKey("FacilityStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FacilityStatus");
                });

            modelBuilder.Entity("Domain.Entities.Patient", b =>
                {
                    b.HasOne("Domain.Entities.Facility", "Facility")
                        .WithMany("Patient")
                        .HasForeignKey("FacilityId");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("Domain.Entities.Facility", b =>
                {
                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Entities.FacilityStatus", b =>
                {
                    b.Navigation("Facility");
                });
#pragma warning restore 612, 618
        }
    }
}