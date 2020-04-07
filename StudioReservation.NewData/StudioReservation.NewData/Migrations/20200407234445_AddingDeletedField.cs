using Microsoft.EntityFrameworkCore.Migrations;

namespace StudioReservation.NewData.Migrations
{
    public partial class AddingDeletedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudioRoomSchedule",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudioRoom",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Studio",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Reservation",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Client",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudioRoomSchedule");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudioRoom");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Studio");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Client");
        }
    }
}
