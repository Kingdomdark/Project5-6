﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Model;
using System;

namespace Webshop.Migrations
{
    [DbContext(typeof(TicketContext))]
    [Migration("20171026203140_InitialCreateWebshop")]
    partial class InitialCreateWebshop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Model.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Userlastname");

                    b.Property<string>("Username");

                    b.Property<string>("_password");

                    b.Property<string>("email_adress");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Model.Theater", b =>
                {
                    b.Property<int>("TheaterID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Available_seats");

                    b.Property<string>("Theateradress");

                    b.Property<string>("Theatername");

                    b.HasKey("TheaterID");

                    b.ToTable("Theaters");
                });

            modelBuilder.Entity("Model.Ticket", b =>
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

            modelBuilder.Entity("Model.Ticket", b =>
                {
                    b.HasOne("Model.Theater", "TheaterID")
                        .WithMany()
                        .HasForeignKey("TheaterID1");
                });
#pragma warning restore 612, 618
        }
    }
}
