using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class updateê : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecruiterGalleriesId",
                table: "RecruiterImages",
                newName: "RecruiterImagesId");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "1fd27e7e-b7a7-482f-9ef5-b2661c766b62");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44dad775-7607-45eb-8431-68c7eb66e923", "AQAAAAEAACcQAAAAEMSEkSopThXuy2IVT0vh1XivPv9yWW37c6Vbw4+e1zZOWN+8J5udTXPLS2ttcdYvxA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecruiterImagesId",
                table: "RecruiterImages",
                newName: "RecruiterGalleriesId");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "507959a0-0b4d-4c4d-9539-d17663b68863");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ea4eed3d-dddd-486f-8373-3f19c58a7e68", "AQAAAAEAACcQAAAAEKETrfXAoTWMCRNg+0W1EkZXxE/11Kx/yLtgc4ANxBdtp92Cad7KDO8O8YBfwKACXw==" });
        }
    }
}
