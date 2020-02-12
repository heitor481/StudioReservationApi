using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StudioReservation.NewData.Migrations
{
    public partial class FistMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(fixedLength: true, nullable: false),
                    LastName = table.Column<string>(fixedLength: true, nullable: false),
                    DateBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client.Address#Address",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Neighborhood = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client.Address#Address", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client.Address#Address_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client.Document#Document",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false),
                    ClientDocument = table.Column<string>(nullable: false),
                    DocumentType = table.Column<int>(nullable: false),
                    IsDocumentValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client.Document#Document", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client.Document#Document_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false),
                    UserEmail = table.Column<string>(maxLength: 60, nullable: false),
                    Password = table.Column<string>(maxLength: 16, nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Email_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumberOfPayment = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    ExpiredDate = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    TotalPaid = table.Column<decimal>(nullable: false),
                    ClientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment.ClientDocument#Document",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false),
                    ClientDocument = table.Column<string>(nullable: false),
                    DocumentType = table.Column<int>(nullable: false),
                    IsDocumentValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment.ClientDocument#Document", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment.ClientDocument#Document_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    NumberOfReservation = table.Column<string>(nullable: true),
                    DateOfTheReservation = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Payment_Id",
                        column: x => x.Id,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Studio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudioName = table.Column<string>(maxLength: 100, nullable: false),
                    ReservationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studio_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Studio.Address#Address",
                columns: table => new
                {
                    StudioId = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Neighborhood = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studio.Address#Address", x => x.StudioId);
                    table.ForeignKey(
                        name: "FK_Studio.Address#Address_Studio_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudioRoom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomNumber = table.Column<int>(nullable: false),
                    IsReserved = table.Column<bool>(nullable: true),
                    StudioId = table.Column<int>(nullable: true),
                    ReservationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudioRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudioRoom_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudioRoom_Studio_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudioRoomSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    StudioId = table.Column<int>(nullable: true),
                    StudioRoomId = table.Column<int>(nullable: true),
                    ReservationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudioRoomSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudioRoomSchedule_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudioRoomSchedule_Studio_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudioRoomSchedule_StudioRoom_StudioRoomId",
                        column: x => x.StudioRoomId,
                        principalTable: "StudioRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ClientId",
                table: "Payment",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ClientId",
                table: "Reservation",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Studio_ReservationId",
                table: "Studio",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudioRoom_ReservationId",
                table: "StudioRoom",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudioRoom_StudioId",
                table: "StudioRoom",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_StudioRoomSchedule_ReservationId",
                table: "StudioRoomSchedule",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudioRoomSchedule_StudioId",
                table: "StudioRoomSchedule",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_StudioRoomSchedule_StudioRoomId",
                table: "StudioRoomSchedule",
                column: "StudioRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client.Address#Address");

            migrationBuilder.DropTable(
                name: "Client.Document#Document");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Payment.ClientDocument#Document");

            migrationBuilder.DropTable(
                name: "Studio.Address#Address");

            migrationBuilder.DropTable(
                name: "StudioRoomSchedule");

            migrationBuilder.DropTable(
                name: "StudioRoom");

            migrationBuilder.DropTable(
                name: "Studio");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
