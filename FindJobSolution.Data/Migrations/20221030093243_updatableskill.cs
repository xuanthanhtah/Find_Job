using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class updatableskill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "c138b4ed-1076-4451-949c-ef85aed21294");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b63a5c0-ec7a-4a04-aac2-7414b0cdd8f7", "AQAAAAEAACcQAAAAELby1XF3WdRR3OtDg/5/hbwLCyAwnz2JvPY998/E5a6eCl6y72kegxt1/i05ZWwPFA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "6dc58c82-4fe8-4915-bd73-f55bd882f162");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a470c35a-c6eb-4e45-b6ab-44a3b43277e0", "AQAAAAEAACcQAAAAEM+QlsGbnrFvhgEhf5J4Nw4yXBCjUjgKuD6MpAaQSGU9GlmDuTcOgj+dERPAzqaDwQ==" });
        }
    }
}
