using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transport_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class navigationpropertiesaddedtotables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Passengers",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Passengers",
                newName: "Age");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Passengers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Passengers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Bookings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_RouteID",
                table: "Trips",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_VehicleID",
                table: "Trips",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PassengerID",
                table: "Bookings",
                column: "PassengerID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TripID",
                table: "Bookings",
                column: "TripID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Passengers_PassengerID",
                table: "Bookings",
                column: "PassengerID",
                principalTable: "Passengers",
                principalColumn: "PassengerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Trips_TripID",
                table: "Bookings",
                column: "TripID",
                principalTable: "Trips",
                principalColumn: "TripID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Routes_RouteID",
                table: "Trips",
                column: "RouteID",
                principalTable: "Routes",
                principalColumn: "RouteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Vehicles_VehicleID",
                table: "Trips",
                column: "VehicleID",
                principalTable: "Vehicles",
                principalColumn: "VehicleID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Passengers_PassengerID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Trips_TripID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Routes_RouteID",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Vehicles_VehicleID",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_RouteID",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_VehicleID",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PassengerID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_TripID",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Passengers",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Passengers",
                newName: "age");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
