using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookQuoteApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedQuotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuoteText = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "QuoteText", "UserId" },
                values: new object[,]
                {
                    { new Guid("12121212-1212-1212-1212-121212121212"), "There is no charm equal to tenderness of heart.", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("34343434-3434-3434-3434-343434343434"), "Every moment is a fresh beginning.", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("56565656-5656-5656-5656-565656565656"), "What we think, we become.", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("78787878-7878-7878-7878-787878787878"), "Happiness depends upon ourselves.", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "It is never too late to become what you might have been.", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "The only way out is through.", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "Not all those who wander are lost.", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), "The future depends on what you do today.", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "Success is the sum of small efforts, repeated day in and day out.", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), "Whatever you are, be a good one.", new Guid("22222222-2222-2222-2222-222222222222") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
