using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelSite.Migrations
{
    public partial class UpdateTouristRouteSchemaNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartureCity",
                table: "TouristRoutes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TravelDays",
                table: "TouristRoutes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripType",
                table: "TouristRoutes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("2430bf64-fd56-460c-8b75-da0a1d1cd74c"),
                columns: new[] { "DepartureCity", "TravelDays", "TripType" },
                values: new object[] { 3, 4, 3 });

            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("39996f34-013c-4fc6-b1b3-0c1036c47110"),
                columns: new[] { "DepartureCity", "TravelDays", "TripType" },
                values: new object[] { 3, 2, 3 });

            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("39996f34-013c-4fc6-b1b3-0c1036c47111"),
                columns: new[] { "DepartureCity", "TravelDays", "TripType" },
                values: new object[] { 3, 4, 3 });

            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("39996f34-013c-4fc6-b1b3-0c1036c47112"),
                columns: new[] { "DepartureCity", "TravelDays", "TripType" },
                values: new object[] { 3, 4, 3 });

            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("39996f34-013c-4fc6-b1b3-0c1036c47113"),
                columns: new[] { "DepartureCity", "TravelDays", "TripType" },
                values: new object[] { 3, 4, 3 });

            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("39996f34-013c-4fc6-b1b3-0c1036c47114"),
                columns: new[] { "DepartureCity", "TravelDays", "TripType" },
                values: new object[] { 3, 4, 3 });

            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("39996f34-013c-4fc6-b1b3-0c1036c47115"),
                columns: new[] { "DepartureCity", "TravelDays", "TripType" },
                values: new object[] { 3, 4, 3 });

            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("39996f34-013c-4fc6-b1b3-0c1036c47116"),
                columns: new[] { "DepartureCity", "TravelDays", "TripType" },
                values: new object[] { 3, 4, 3 });

            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("39996f34-013c-4fc6-b1b3-0c1036c47117"),
                columns: new[] { "DepartureCity", "TravelDays", "TripType" },
                values: new object[] { 3, 4, 3 });

            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("39996f34-013c-4fc6-b1b3-0c1036c47118"),
                columns: new[] { "DepartureCity", "TravelDays", "TripType" },
                values: new object[] { 3, 4, 3 });

            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("39996f34-013c-4fc6-b1b3-0c1036c47119"),
                columns: new[] { "DepartureCity", "TravelDays", "TripType" },
                values: new object[] { 3, 4, 3 });

            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("39996f34-013c-4fc6-b1b3-0c1036c47169"),
                columns: new[] { "DepartureCity", "TravelDays", "TripType" },
                values: new object[] { 3, 6, 3 });

            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("3ecbcd92-a9e0-45f7-9b29-e03272cb0862"),
                columns: new[] { "DepartureCity", "TravelDays", "TripType" },
                values: new object[] { 1, 4, 3 });

            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("88cf89b9-e4b5-4b42-a5bf-622bd3039601"),
                columns: new[] { "DepartureCity", "TravelDays", "TripType" },
                values: new object[] { 2, 2, 4 });

            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("fb6d4f10-79ed-4aff-a915-4ce29dc9c7e1"),
                columns: new[] { "DepartureCity", "TravelDays", "TripType" },
                values: new object[] { 0, 8, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureCity",
                table: "TouristRoutes");

            migrationBuilder.DropColumn(
                name: "TravelDays",
                table: "TouristRoutes");

            migrationBuilder.DropColumn(
                name: "TripType",
                table: "TouristRoutes");
        }
    }
}
