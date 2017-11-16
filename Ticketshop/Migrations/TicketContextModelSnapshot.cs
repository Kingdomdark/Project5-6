﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Ticketshop.Models;

namespace Ticketshop.Migrations
{
    [DbContext(typeof(TicketContext))]
    partial class TicketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Ticketshop.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email_adress");

                    b.Property<string>("Password");

                    b.Property<string>("Userlastname");

                    b.Property<string>("Username");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Ticketshop.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerID1");

                    b.Property<int?>("TicketID1");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID1");

                    b.HasIndex("TicketID1");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Ticketshop.Models.Theater", b =>
                {
                    b.Property<int>("TheaterID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Available_seats");

                    b.Property<string>("Theateradress");

                    b.Property<string>("Theatername");

                    b.HasKey("TheaterID");

                    b.ToTable("Theaters");
                });

            modelBuilder.Entity("Ticketshop.Models.Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Eventname");

                    b.Property<string>("Genre");

                    b.Property<float>("Price");

                    b.Property<int?>("TheaterID1");

                    b.HasKey("TicketID");

                    b.HasIndex("TheaterID1");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Ticketshop.Models.Order", b =>
                {
                    b.HasOne("Ticketshop.Models.Customer", "CustomerID")
                        .WithMany()
                        .HasForeignKey("CustomerID1");

                    b.HasOne("Ticketshop.Models.Ticket", "TicketID")
                        .WithMany()
                        .HasForeignKey("TicketID1");
                });

            modelBuilder.Entity("Ticketshop.Models.Ticket", b =>
                {
                    b.HasOne("Ticketshop.Models.Theater", "TheaterID")
                        .WithMany()
                        .HasForeignKey("TheaterID1");
                });
#pragma warning restore 612, 618
        }
    }
}
