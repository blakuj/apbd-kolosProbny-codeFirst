﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240609090845_AddData")]
    partial class AddData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Clients", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("ClientID");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ClientID = 1,
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            ClientID = 2,
                            FirstName = "Jane",
                            LastName = "Smith"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Employees", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            FirstName = "Alice",
                            LastName = "Johnson"
                        },
                        new
                        {
                            EmployeeID = 2,
                            FirstName = "Bob",
                            LastName = "Brown"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Order_pastry", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PastryId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("OrderId", "PastryId");

                    b.HasIndex("PastryId");

                    b.ToTable("Order_pastry");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            PastryId = 1,
                            Amount = 3,
                            Comment = "For breakfast"
                        },
                        new
                        {
                            OrderId = 2,
                            PastryId = 2,
                            Amount = 5,
                            Comment = "For meeting"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("AcceptedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FulfilledAt")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            AcceptedAt = new DateTime(2024, 6, 9, 11, 8, 45, 133, DateTimeKind.Local).AddTicks(2502),
                            ClientId = 1,
                            Comments = "First order",
                            EmployeeId = 1,
                            FulfilledAt = new DateTime(2024, 6, 9, 13, 8, 45, 133, DateTimeKind.Local).AddTicks(2545)
                        },
                        new
                        {
                            OrderId = 2,
                            AcceptedAt = new DateTime(2024, 6, 9, 11, 8, 45, 133, DateTimeKind.Local).AddTicks(2550),
                            ClientId = 2,
                            Comments = "Second order",
                            EmployeeId = 2,
                            FulfilledAt = new DateTime(2024, 6, 9, 14, 8, 45, 133, DateTimeKind.Local).AddTicks(2551)
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Pastry", b =>
                {
                    b.Property<int>("PastryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PastryID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("PastryID");

                    b.ToTable("Pastry");

                    b.HasData(
                        new
                        {
                            PastryID = 1,
                            Name = "Croissant",
                            Price = 2.5,
                            Type = "Bread"
                        },
                        new
                        {
                            PastryID = 2,
                            Name = "Muffin",
                            Price = 3.0,
                            Type = "Cake"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Order_pastry", b =>
                {
                    b.HasOne("WebApplication1.Models.Orders", "Order")
                        .WithMany("OrderPastries")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Pastry", "Pastry")
                        .WithMany("OrderPastries")
                        .HasForeignKey("PastryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pastry");
                });

            modelBuilder.Entity("WebApplication1.Models.Orders", b =>
                {
                    b.HasOne("WebApplication1.Models.Clients", "Client")
                        .WithMany("OrdersCollection")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Employees", "Employee")
                        .WithMany("OrdersCollection")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("WebApplication1.Models.Clients", b =>
                {
                    b.Navigation("OrdersCollection");
                });

            modelBuilder.Entity("WebApplication1.Models.Employees", b =>
                {
                    b.Navigation("OrdersCollection");
                });

            modelBuilder.Entity("WebApplication1.Models.Orders", b =>
                {
                    b.Navigation("OrderPastries");
                });

            modelBuilder.Entity("WebApplication1.Models.Pastry", b =>
                {
                    b.Navigation("OrderPastries");
                });
#pragma warning restore 612, 618
        }
    }
}
