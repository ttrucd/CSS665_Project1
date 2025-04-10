﻿// <auto-generated />
using System;
using ITAMS_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITAMS_App.Migrations
{
    [DbContext(typeof(ITAMSDbContext))]
    partial class ITAMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ITAMS_App.Models.Administrator", b =>
                {
                    b.Property<int>("Admin_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Admin_Id"));

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Permission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Admin_Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("ITAMS_App.Models.Asset", b =>
                {
                    b.Property<int>("Asset_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Asset_Id"));

                    b.Property<int>("AssetType_Id")
                        .HasColumnType("int")
                        .HasColumnName("AssetType_Id");

                    b.Property<string>("Asset_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Purchase_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Serial_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Asset_Id");

                    b.HasIndex("AssetType_Id");

                    b.HasIndex("Asset_Id");

                    b.HasIndex("Serial_Number")
                        .IsUnique();

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("ITAMS_App.Models.AssetType", b =>
                {
                    b.Property<int>("AssetType_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssetType_Id"));

                    b.Property<string>("Type_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssetType_Id");

                    b.ToTable("AssetTypes");
                });

            modelBuilder.Entity("ITAMS_App.Models.Employee", b =>
                {
                    b.Property<int>("Employee_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Employee_Id"));

                    b.Property<int?>("Assigned_Asset_Id")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Employee_Id");

                    b.HasIndex("Assigned_Asset_Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ITAMS_App.Models.MaintenanceRecord", b =>
                {
                    b.Property<int>("Record_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Record_Id"));

                    b.Property<int>("Asset_Id")
                        .HasColumnType("int");

                    b.Property<string>("Issue_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Maintenance_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Technician_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Record_Id");

                    b.HasIndex("Asset_Id");

                    b.ToTable("MaintenanceRecords");
                });

            modelBuilder.Entity("ITAMS_App.Models.SoftwareLicense", b =>
                {
                    b.Property<int>("License_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("License_Id"));

                    b.Property<int?>("Assigned_Employee_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Expiration_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("License_Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Software_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("License_Id");

                    b.HasIndex("Assigned_Employee_Id");

                    b.HasIndex("License_Key")
                        .IsUnique();

                    b.ToTable("SoftwareLicense");
                });

            modelBuilder.Entity("ITAMS_App.Models.Asset", b =>
                {
                    b.HasOne("ITAMS_App.Models.AssetType", "AssetType")
                        .WithMany("Assets")
                        .HasForeignKey("AssetType_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssetType");
                });

            modelBuilder.Entity("ITAMS_App.Models.Employee", b =>
                {
                    b.HasOne("ITAMS_App.Models.Asset", "AssignedAsset")
                        .WithMany()
                        .HasForeignKey("Assigned_Asset_Id");

                    b.Navigation("AssignedAsset");
                });

            modelBuilder.Entity("ITAMS_App.Models.MaintenanceRecord", b =>
                {
                    b.HasOne("ITAMS_App.Models.Asset", "Asset")
                        .WithMany("MaintenanceRecords")
                        .HasForeignKey("Asset_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");
                });

            modelBuilder.Entity("ITAMS_App.Models.SoftwareLicense", b =>
                {
                    b.HasOne("ITAMS_App.Models.Employee", "AssignedEmployee")
                        .WithMany()
                        .HasForeignKey("Assigned_Employee_Id");

                    b.Navigation("AssignedEmployee");
                });

            modelBuilder.Entity("ITAMS_App.Models.Asset", b =>
                {
                    b.Navigation("MaintenanceRecords");
                });

            modelBuilder.Entity("ITAMS_App.Models.AssetType", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
