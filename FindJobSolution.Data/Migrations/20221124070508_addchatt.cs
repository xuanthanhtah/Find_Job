using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class addchatt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "ba6fc8ed-53cd-4734-bf6e-513e8c7e38ad");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("728d69ec-5ff4-4688-9107-d8906b264f79"),
                column: "ConcurrencyStamp",
                value: "f2f98c4b-0a25-4a39-8eb9-de8318dad333");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f91c93e9-5527-4162-b7c5-dd3cba713a49"),
                column: "ConcurrencyStamp",
                value: "e8a7a400-995f-4f4c-9865-e91ad9a3ccad");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0b85d273-a1e9-473e-9106-f9f826466238", "AQAAAAEAACcQAAAAENddOVV04snqhbuoHDntObKlFVrFozxvHe+78p4tHuVBLS3HsuuC51+Ah95JmkQHsQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_userId",
                table: "Messages",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "e020c450-fb51-4324-bae8-581b9a4a0325");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("728d69ec-5ff4-4688-9107-d8906b264f79"),
                column: "ConcurrencyStamp",
                value: "137845b2-0796-4874-a923-ea8675c8bba2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f91c93e9-5527-4162-b7c5-dd3cba713a49"),
                column: "ConcurrencyStamp",
                value: "7c538477-22f5-4721-af57-8025c208e2d4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2b632092-d7de-4167-88ea-e0a0964a0061", "AQAAAAEAACcQAAAAEN7SJHOBrtpt9G0myzD3GDNwpVj1lSWpLHD9dQ2YvR5xCsdqkL73WDsOnsHIJCNjYw==" });
        }
    }
}
