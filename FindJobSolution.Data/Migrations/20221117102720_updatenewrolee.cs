using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class updatenewrolee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "e020c450-fb51-4324-bae8-581b9a4a0325");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("728d69ec-5ff4-4688-9107-d8906b264f79"), "137845b2-0796-4874-a923-ea8675c8bba2", "JobSeeker", "JobSeeker" },
                    { new Guid("f91c93e9-5527-4162-b7c5-dd3cba713a49"), "7c538477-22f5-4721-af57-8025c208e2d4", "Recuiter", "Recuiter" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2b632092-d7de-4167-88ea-e0a0964a0061", "AQAAAAEAACcQAAAAEN7SJHOBrtpt9G0myzD3GDNwpVj1lSWpLHD9dQ2YvR5xCsdqkL73WDsOnsHIJCNjYw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("728d69ec-5ff4-4688-9107-d8906b264f79"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f91c93e9-5527-4162-b7c5-dd3cba713a49"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "66493a44-c516-4d90-9841-0ca81660471b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fbfec6e2-fc9a-49ae-919a-f8aeddbf13b1", "AQAAAAEAACcQAAAAEAO9eG0+6rO564Rp156dHPZjLNZNS6jVr3sPlXxlPXRyrjzI590AY4DJhKwUhvtALw==" });
        }
    }
}
