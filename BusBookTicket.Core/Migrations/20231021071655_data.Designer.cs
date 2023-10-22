﻿// <auto-generated />
using System;
using BusBookTicket.Core.Models.EntityFW;
using BusBookTicket.Core.Models.EntityFW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusBookTicket.Core.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20231021071655_data")]
    partial class data
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Account", b =>
                {
                    b.Property<int>("accountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("accountID"));

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleID")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("accountID");

                    b.HasAlternateKey("username");

                    b.HasIndex("roleID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Bus", b =>
                {
                    b.Property<int>("busID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("busID"));

                    b.Property<string>("busNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("busTypeID")
                        .HasColumnType("int");

                    b.Property<int>("companyID")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("busID");

                    b.HasIndex("busTypeID");

                    b.HasIndex("companyID");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.BusStation", b =>
                {
                    b.Property<int>("busStationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("busStationID"));

                    b.Property<string>("address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("busStationID");

                    b.ToTable("BusStations");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.BusStop", b =>
                {
                    b.Property<int>("busStopID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("busStopID"));

                    b.Property<int>("busID")
                        .HasColumnType("int");

                    b.Property<int>("busStationID")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("busStopID");

                    b.HasIndex("busID");

                    b.HasIndex("busStationID");

                    b.ToTable("BusStops");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.BusType", b =>
                {
                    b.Property<int>("busTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("busTypeID"));

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("totalSeats")
                        .HasColumnType("int");

                    b.HasKey("busTypeID");

                    b.ToTable("BusesType");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Company", b =>
                {
                    b.Property<int>("companyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("companyID"));

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("introduction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("companyID");

                    b.HasIndex("accountID")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Customer", b =>
                {
                    b.Property<int>("customerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customerID"));

                    b.Property<int>("accountID")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("dateCreate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateOfBirth")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateUpdate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("fullName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("gender")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("rankID")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("customerID");

                    b.HasIndex("accountID")
                        .IsUnique();

                    b.HasIndex("customerID");

                    b.HasIndex("rankID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Discount", b =>
                {
                    b.Property<int>("discountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("discountID"));

                    b.Property<DateTime>("dateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int?>("rankID")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("discountID");

                    b.HasIndex("rankID");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Rank", b =>
                {
                    b.Property<int>("rankID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("rankID"));

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("rankID");

                    b.ToTable("Ranks");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Review", b =>
                {
                    b.Property<int>("reviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reviewID"));

                    b.Property<int>("busID")
                        .HasColumnType("int");

                    b.Property<int>("customerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rate")
                        .HasColumnType("int");

                    b.Property<string>("reviews")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("reviewID");

                    b.HasIndex("busID");

                    b.HasIndex("customerID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Role", b =>
                {
                    b.Property<int>("roleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleID"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("roleID");

                    b.HasAlternateKey("roleName");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.SeatItem", b =>
                {
                    b.Property<int>("seatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("seatID"));

                    b.Property<int>("busID")
                        .HasColumnType("int");

                    b.Property<int>("seatNumber")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("seatID");

                    b.HasIndex("busID");

                    b.ToTable("SeatItems");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Ticket", b =>
                {
                    b.Property<int>("ticketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ticketID"));

                    b.Property<int>("busStationEndID")
                        .HasColumnType("int");

                    b.Property<int>("busStationStartID")
                        .HasColumnType("int");

                    b.Property<int>("customerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateDeparture")
                        .HasColumnType("datetime2");

                    b.Property<int>("discountID")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<long>("totolPrice")
                        .HasColumnType("bigint");

                    b.HasKey("ticketID");

                    b.HasIndex("busStationEndID");

                    b.HasIndex("busStationStartID");

                    b.HasIndex("customerID");

                    b.HasIndex("discountID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.TicketItem", b =>
                {
                    b.Property<int>("ticketItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ticketItemID"));

                    b.Property<int>("seatID")
                        .HasColumnType("int");

                    b.Property<int>("ticketID")
                        .HasColumnType("int");

                    b.HasKey("ticketItemID");

                    b.HasIndex("seatID")
                        .IsUnique();

                    b.HasIndex("ticketID");

                    b.ToTable("TicketItems");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Account", b =>
                {
                    b.HasOne("BusBookTicket.Core.Models.Entity.Role", "role")
                        .WithMany("accounts")
                        .HasForeignKey("roleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("role");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Bus", b =>
                {
                    b.HasOne("BusBookTicket.Core.Models.Entity.BusType", "busType")
                        .WithMany("buses")
                        .HasForeignKey("busTypeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BusBookTicket.Core.Models.Entity.Company", "company")
                        .WithMany("buses")
                        .HasForeignKey("companyID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("busType");

                    b.Navigation("company");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.BusStop", b =>
                {
                    b.HasOne("BusBookTicket.Core.Models.Entity.Bus", "bus")
                        .WithMany("busStops")
                        .HasForeignKey("busID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BusBookTicket.Core.Models.Entity.BusStation", "BusStation")
                        .WithMany("busStops")
                        .HasForeignKey("busStationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BusStation");

                    b.Navigation("bus");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Company", b =>
                {
                    b.HasOne("BusBookTicket.Core.Models.Entity.Account", "account")
                        .WithOne("company")
                        .HasForeignKey("BusBookTicket.Core.Models.Entity.Company", "accountID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("account");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Customer", b =>
                {
                    b.HasOne("BusBookTicket.Core.Models.Entity.Account", "account")
                        .WithOne("customer")
                        .HasForeignKey("BusBookTicket.Core.Models.Entity.Customer", "accountID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BusBookTicket.Core.Models.Entity.Rank", "rank")
                        .WithMany("customers")
                        .HasForeignKey("rankID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("account");

                    b.Navigation("rank");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Discount", b =>
                {
                    b.HasOne("BusBookTicket.Core.Models.Entity.Rank", "rank")
                        .WithMany("discounts")
                        .HasForeignKey("rankID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("rank");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Review", b =>
                {
                    b.HasOne("BusBookTicket.Core.Models.Entity.Bus", "bus")
                        .WithMany("reviews")
                        .HasForeignKey("busID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BusBookTicket.Core.Models.Entity.Customer", "customer")
                        .WithMany("reviews")
                        .HasForeignKey("customerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("bus");

                    b.Navigation("customer");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.SeatItem", b =>
                {
                    b.HasOne("BusBookTicket.Core.Models.Entity.Bus", "bus")
                        .WithMany("Seats")
                        .HasForeignKey("busID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("bus");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Ticket", b =>
                {
                    b.HasOne("BusBookTicket.Core.Models.Entity.BusStation", "busStationEnd")
                        .WithMany("ticketends")
                        .HasForeignKey("busStationEndID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BusBookTicket.Core.Models.Entity.BusStation", "busStationStart")
                        .WithMany("ticketStarts")
                        .HasForeignKey("busStationStartID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BusBookTicket.Core.Models.Entity.Customer", "customer")
                        .WithMany("tickets")
                        .HasForeignKey("customerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BusBookTicket.Core.Models.Entity.Discount", "discount")
                        .WithMany("tickets")
                        .HasForeignKey("discountID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("busStationEnd");

                    b.Navigation("busStationStart");

                    b.Navigation("customer");

                    b.Navigation("discount");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.TicketItem", b =>
                {
                    b.HasOne("BusBookTicket.Core.Models.Entity.SeatItem", "seat")
                        .WithOne("ticketItem")
                        .HasForeignKey("BusBookTicket.Core.Models.Entity.TicketItem", "seatID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BusBookTicket.Core.Models.Entity.Ticket", "ticket")
                        .WithMany("ticketItems")
                        .HasForeignKey("ticketID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("seat");

                    b.Navigation("ticket");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Account", b =>
                {
                    b.Navigation("company")
                        .IsRequired();

                    b.Navigation("customer")
                        .IsRequired();
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Bus", b =>
                {
                    b.Navigation("Seats");

                    b.Navigation("busStops");

                    b.Navigation("reviews");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.BusStation", b =>
                {
                    b.Navigation("busStops");

                    b.Navigation("ticketStarts");

                    b.Navigation("ticketends");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.BusType", b =>
                {
                    b.Navigation("buses");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Company", b =>
                {
                    b.Navigation("buses");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Customer", b =>
                {
                    b.Navigation("reviews");

                    b.Navigation("tickets");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Discount", b =>
                {
                    b.Navigation("tickets");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Rank", b =>
                {
                    b.Navigation("customers");

                    b.Navigation("discounts");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Role", b =>
                {
                    b.Navigation("accounts");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.SeatItem", b =>
                {
                    b.Navigation("ticketItem");
                });

            modelBuilder.Entity("BusBookTicket.Core.Models.Entity.Ticket", b =>
                {
                    b.Navigation("ticketItems");
                });
#pragma warning restore 612, 618
        }
    }
}