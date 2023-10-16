using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelSite.Migrations
{
    public partial class UpdateTouristRouteData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("a1fd0bee-0afc-4586-96c8-f46b7c99d2a0"),
                columns: new[] { "Rating", "TravelDays" },
                values: new object[] { 3.5, 8 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("a1fd0bee-0afc-4586-96c8-f46b7c99d2a0"),
                columns: new[] { "Rating", "TravelDays" },
                values: new object[] { null, null });
        }
    }
}
