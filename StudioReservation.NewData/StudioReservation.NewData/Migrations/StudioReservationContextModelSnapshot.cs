﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudioReservation.NewData;

namespace StudioReservation.NewData.Migrations
{
    [DbContext(typeof(StudioReservationContext))]
    partial class StudioReservationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("StudioReservation.NewDomain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .IsFixedLength(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .IsFixedLength(true);

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("StudioReservation.NewDomain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int?>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("NumberOfPayment")
                        .HasColumnType("text");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalPaid")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("StudioReservation.NewDomain.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfTheReservation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("NumberOfReservation")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("StudioReservation.NewDomain.Entities.Studio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ReservationId")
                        .HasColumnType("integer");

                    b.Property<string>("StudioName")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("Studio");
                });

            modelBuilder.Entity("StudioReservation.NewDomain.Entities.StudioRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool?>("IsReserved")
                        .HasColumnType("boolean");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("integer");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("integer");

                    b.Property<int?>("StudioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("StudioId");

                    b.ToTable("StudioRoom");
                });

            modelBuilder.Entity("StudioReservation.NewDomain.Entities.StudioRoomSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("StudioId")
                        .HasColumnType("integer");

                    b.Property<int?>("StudioRoomId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("StudioId");

                    b.HasIndex("StudioRoomId");

                    b.ToTable("StudioRoomSchedule");
                });

            modelBuilder.Entity("StudioReservation.NewDomain.Entities.Client", b =>
                {
                    b.OwnsOne("StudioReservation.NewDomain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("ClientId")
                                .HasColumnType("integer");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("ClientId");

                            b1.ToTable("Client.Address#Address");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.OwnsOne("StudioReservation.NewDomain.ValueObjects.Document", "Document", b1 =>
                        {
                            b1.Property<int>("ClientId")
                                .HasColumnType("integer");

                            b1.Property<string>("ClientDocument")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<int>("DocumentType")
                                .HasColumnType("integer");

                            b1.Property<bool>("IsDocumentValid")
                                .HasColumnType("boolean");

                            b1.HasKey("ClientId");

                            b1.ToTable("Client.Document#Document");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.OwnsOne("StudioReservation.NewDomain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("ClientId")
                                .HasColumnType("integer");

                            b1.Property<string>("ConfirmPassword")
                                .HasColumnType("text");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("character varying(16)")
                                .HasMaxLength(16);

                            b1.Property<string>("UserEmail")
                                .IsRequired()
                                .HasColumnType("character varying(60)")
                                .HasMaxLength(60);

                            b1.HasKey("ClientId");

                            b1.ToTable("Email");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });
                });

            modelBuilder.Entity("StudioReservation.NewDomain.Entities.Payment", b =>
                {
                    b.HasOne("StudioReservation.NewDomain.Entities.Client", "Client")
                        .WithMany("Payment")
                        .HasForeignKey("ClientId");

                    b.HasOne("StudioReservation.NewDomain.Entities.Reservation", "Reservation")
                        .WithOne("Payment")
                        .HasForeignKey("StudioReservation.NewDomain.Entities.Payment", "Id")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.OwnsOne("StudioReservation.NewDomain.ValueObjects.Document", "ClientDocument", b1 =>
                        {
                            b1.Property<int>("PaymentId")
                                .HasColumnType("integer");

                            b1.Property<string>("ClientDocument")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<int>("DocumentType")
                                .HasColumnType("integer");

                            b1.Property<bool>("IsDocumentValid")
                                .HasColumnType("boolean");

                            b1.HasKey("PaymentId");

                            b1.ToTable("Payment.ClientDocument#Document");

                            b1.WithOwner()
                                .HasForeignKey("PaymentId");
                        });
                });

            modelBuilder.Entity("StudioReservation.NewDomain.Entities.Reservation", b =>
                {
                    b.HasOne("StudioReservation.NewDomain.Entities.Client", "Client")
                        .WithMany("Reservation")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("StudioReservation.NewDomain.Entities.Studio", b =>
                {
                    b.HasOne("StudioReservation.NewDomain.Entities.Reservation", null)
                        .WithMany("Studio")
                        .HasForeignKey("ReservationId");

                    b.OwnsOne("StudioReservation.NewDomain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("StudioId")
                                .HasColumnType("integer");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("StudioId");

                            b1.ToTable("Studio.Address#Address");

                            b1.WithOwner()
                                .HasForeignKey("StudioId");
                        });
                });

            modelBuilder.Entity("StudioReservation.NewDomain.Entities.StudioRoom", b =>
                {
                    b.HasOne("StudioReservation.NewDomain.Entities.Reservation", null)
                        .WithMany("StudioRoom")
                        .HasForeignKey("ReservationId");

                    b.HasOne("StudioReservation.NewDomain.Entities.Studio", "Studio")
                        .WithMany("StudioRoom")
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudioReservation.NewDomain.Entities.StudioRoomSchedule", b =>
                {
                    b.HasOne("StudioReservation.NewDomain.Entities.Reservation", null)
                        .WithMany("StudioRoomSchedule")
                        .HasForeignKey("ReservationId");

                    b.HasOne("StudioReservation.NewDomain.Entities.Studio", "Studio")
                        .WithMany("StudioRoomSchedule")
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudioReservation.NewDomain.Entities.StudioRoom", "StudioRoom")
                        .WithMany("StudioRoomSchedule")
                        .HasForeignKey("StudioRoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
