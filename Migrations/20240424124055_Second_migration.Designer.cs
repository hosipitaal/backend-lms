﻿// <auto-generated />
using System;
using LeaveManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LeaveManagementSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240424124055_Second_migration")]
    partial class Second_migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LeaveManagementSystem.Models.Employee", b =>
                {
                    b.Property<int>("emp_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("emp_id"));

                    b.Property<string>("emp_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emp_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emp_phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("mgr_id")
                        .HasColumnType("int");

                    b.Property<string>("mgr_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("emp_id");

                    b.ToTable("AllEmployees");
                });

            modelBuilder.Entity("LeaveManagementSystem.Models.Leaves", b =>
                {
                    b.Property<int>("leave_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("leave_id"));

                    b.Property<int>("daysofleave")
                        .HasColumnType("int");

                    b.Property<int>("emp_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("end_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("mgr_id")
                        .HasColumnType("int");

                    b.Property<string>("reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("start_date")
                        .HasColumnType("datetime2");

                    b.HasKey("leave_id");

                    b.ToTable("AllLeaves");
                });
#pragma warning restore 612, 618
        }
    }
}