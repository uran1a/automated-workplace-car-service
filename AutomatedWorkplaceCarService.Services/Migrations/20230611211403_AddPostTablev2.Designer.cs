﻿// <auto-generated />
using System;
using AutomatedWorkplaceCarService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutomatedWorkplaceCarService.Services.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230611211403_AddPostTablev2")]
    partial class AddPostTablev2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Amount")
                        .HasColumnType("integer");

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<string>("Descriptions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndWork")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<int>("Stage")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartWork")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EnginePower")
                        .HasColumnType("integer");

                    b.Property<int>("ModelId")
                        .HasColumnType("integer");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<int>("Transmission")
                        .HasColumnType("integer");

                    b.Property<int>("YearOfRelease")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("integer");

                    b.Property<int?>("CarId")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("CarId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Client", b =>
                {
                    b.HasBaseType("AutomatedWorkplaceCarService.Models.User");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Employee", b =>
                {
                    b.HasBaseType("AutomatedWorkplaceCarService.Models.User");

                    b.Property<int?>("PostId")
                        .HasColumnType("integer");

                    b.HasIndex("PostId");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Application", b =>
                {
                    b.HasOne("AutomatedWorkplaceCarService.Models.Car", "Car")
                        .WithMany("Applications")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomatedWorkplaceCarService.Models.Client", "Client")
                        .WithMany("Applications")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomatedWorkplaceCarService.Models.Employee", "Employee")
                        .WithMany("Applications")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomatedWorkplaceCarService.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Client");

                    b.Navigation("Employee");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Car", b =>
                {
                    b.HasOne("AutomatedWorkplaceCarService.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomatedWorkplaceCarService.Models.Client", "Owner")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Image", b =>
                {
                    b.HasOne("AutomatedWorkplaceCarService.Models.Application", "Application")
                        .WithMany("Images")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("AutomatedWorkplaceCarService.Models.Car", "Car")
                        .WithMany("Images")
                        .HasForeignKey("CarId");

                    b.Navigation("Application");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Model", b =>
                {
                    b.HasOne("AutomatedWorkplaceCarService.Models.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Employee", b =>
                {
                    b.HasOne("AutomatedWorkplaceCarService.Models.Post", "Post")
                        .WithMany("Employees")
                        .HasForeignKey("PostId");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Application", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Car", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Post", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Client", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Cars");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.Models.Employee", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
