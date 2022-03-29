using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ironcapital.Migrations
{
    public partial class m0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    TokenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Price = table.Column<float>(nullable: false),
                    Owner = table.Column<string>(maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.TokenId);
                });

            migrationBuilder.CreateTable(
                name: "BuyNow",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(maxLength: 10, nullable: false),
                    TokenId = table.Column<int>(nullable: false),
                    WalletAddress = table.Column<string>(nullable: false),
                    TwitterID = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    RecBy = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyNow", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_BuyNow_Token_TokenId",
                        column: x => x.TokenId,
                        principalTable: "Token",
                        principalColumn: "TokenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyNow_TokenId",
                table: "BuyNow",
                column: "TokenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyNow");

            migrationBuilder.DropTable(
                name: "Token");
        }
    }
}
