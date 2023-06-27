﻿// <auto-generated />
using System;
using AutomatedWorkplaceCarService.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutomatedWorkplaceCarService.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230626085456_InitStartData")]
    partial class InitStartData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
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

                    b.Property<int>("StageId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartWork")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("StageId");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Brand", b =>
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

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Car", b =>
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

                    b.Property<int>("TransmissionId")
                        .HasColumnType("integer");

                    b.Property<int>("YearOfRelease")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TransmissionId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Image", b =>
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

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Model", b =>
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

                    b.ToTable("Models");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Post", b =>
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Администратор"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Автомеханик"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Автоэлектрик"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Автодиагност"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Автомаляр"
                        });
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Role", b =>
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

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "client"
                        },
                        new
                        {
                            Id = 3,
                            Name = "employee"
                        });
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Service", b =>
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

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Stage", b =>
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

                    b.ToTable("Stage");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Transmission", b =>
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

                    b.ToTable("Transmissions");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.User", b =>
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

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Client", b =>
                {
                    b.HasBaseType("AutomatedWorkplaceCarService.DAL.Entities.User");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Employee", b =>
                {
                    b.HasBaseType("AutomatedWorkplaceCarService.DAL.Entities.User");

                    b.Property<int?>("PostId")
                        .HasColumnType("integer");

                    b.HasIndex("PostId");

                    b.HasDiscriminator().HasValue("Employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "admin",
                            Name = "Иван",
                            Password = "123",
                            Patronymic = "Иванович",
                            RoleId = 1,
                            Surname = "Иванов",
                            PostId = 1
                        });
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Application", b =>
                {
                    b.HasOne("AutomatedWorkplaceCarService.DAL.Entities.Car", "Car")
                        .WithMany("Applications")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomatedWorkplaceCarService.DAL.Entities.Client", "Client")
                        .WithMany("Applications")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomatedWorkplaceCarService.DAL.Entities.Employee", "Employee")
                        .WithMany("Applications")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomatedWorkplaceCarService.DAL.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomatedWorkplaceCarService.DAL.Entities.Stage", "Stage")
                        .WithMany("Applications")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Client");

                    b.Navigation("Employee");

                    b.Navigation("Service");

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Car", b =>
                {
                    b.HasOne("AutomatedWorkplaceCarService.DAL.Entities.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomatedWorkplaceCarService.DAL.Entities.Client", "Owner")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomatedWorkplaceCarService.DAL.Entities.Transmission", "Transmission")
                        .WithMany("Cars")
                        .HasForeignKey("TransmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("Owner");

                    b.Navigation("Transmission");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Image", b =>
                {
                    b.HasOne("AutomatedWorkplaceCarService.DAL.Entities.Application", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationId");

                    b.HasOne("AutomatedWorkplaceCarService.DAL.Entities.Car", "Car")
                        .WithMany("Images")
                        .HasForeignKey("CarId");

                    b.Navigation("Application");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Model", b =>
                {
                    b.HasOne("AutomatedWorkplaceCarService.DAL.Entities.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.User", b =>
                {
                    b.HasOne("AutomatedWorkplaceCarService.DAL.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Employee", b =>
                {
                    b.HasOne("AutomatedWorkplaceCarService.DAL.Entities.Post", "Post")
                        .WithMany("Employees")
                        .HasForeignKey("PostId");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Car", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Post", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Stage", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Transmission", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Client", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Cars");
                });

            modelBuilder.Entity("AutomatedWorkplaceCarService.DAL.Entities.Employee", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
