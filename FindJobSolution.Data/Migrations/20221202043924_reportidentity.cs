using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class reportidentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "72698436-a03a-4ad6-9ebe-ac98c0002f39");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("728d69ec-5ff4-4688-9107-d8906b264f79"),
                column: "ConcurrencyStamp",
                value: "acecfeb8-b639-4660-aac7-b70aef1f073f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f91c93e9-5527-4162-b7c5-dd3cba713a49"),
                column: "ConcurrencyStamp",
                value: "b003ec6f-72fb-45ed-bd49-e5e7a65647ab");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "799d3db8-35fe-4a51-9467-dc50a9a2cb87", "AQAAAAEAACcQAAAAEG5xGHHrUxW1jmaznULbqxoKVJTRyjxV7BPkffh1i/MbeNf/EqT2QoDcsejb7w9GZA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "745c632e-06be-4880-8d81-887f89a8c5db");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("728d69ec-5ff4-4688-9107-d8906b264f79"),
                column: "ConcurrencyStamp",
                value: "a407d56f-5032-4d2b-a4f4-9b571a0d4325");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f91c93e9-5527-4162-b7c5-dd3cba713a49"),
                column: "ConcurrencyStamp",
                value: "295e7c8f-4a00-4a3c-a70e-8da9c1f8970f");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a59a4f53-4f86-464a-8e11-bdb75184363a", "AQAAAAEAACcQAAAAECb/46YbJQDWfzQQnDM+DTo4EKLhP4q5aDLsNwdRLKlONNnva6f3ovMUAFteLikI2Q==" });
        }
    }
}
