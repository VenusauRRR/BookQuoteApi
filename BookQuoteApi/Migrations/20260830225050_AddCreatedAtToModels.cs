using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookQuoteApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedAtToModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Quotes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 22, 50, 50, 94, DateTimeKind.Utc).AddTicks(5858));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 22, 50, 50, 94, DateTimeKind.Utc).AddTicks(7403));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 22, 50, 50, 94, DateTimeKind.Utc).AddTicks(7415));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: new Guid("12121212-1212-1212-1212-121212121212"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 22, 50, 50, 95, DateTimeKind.Utc).AddTicks(6833));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: new Guid("34343434-3434-3434-3434-343434343434"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 22, 50, 50, 95, DateTimeKind.Utc).AddTicks(6836));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: new Guid("56565656-5656-5656-5656-565656565656"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 22, 50, 50, 95, DateTimeKind.Utc).AddTicks(6838));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: new Guid("78787878-7878-7878-7878-787878787878"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 22, 50, 50, 95, DateTimeKind.Utc).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 22, 50, 50, 95, DateTimeKind.Utc).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 22, 50, 50, 95, DateTimeKind.Utc).AddTicks(6818));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 22, 50, 50, 95, DateTimeKind.Utc).AddTicks(6824));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 22, 50, 50, 95, DateTimeKind.Utc).AddTicks(6826));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 22, 50, 50, 95, DateTimeKind.Utc).AddTicks(6829));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 22, 50, 50, 95, DateTimeKind.Utc).AddTicks(6831));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Books");
        }
    }
}
