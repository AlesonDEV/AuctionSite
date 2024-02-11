using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auctiion.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auction_Details_Customers_current_buyer_id",
                table: "Auction_Details");

            migrationBuilder.AlterColumn<int>(
                name: "current_buyer_id",
                table: "Auction_Details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Auction_Details_Customers_current_buyer_id",
                table: "Auction_Details",
                column: "current_buyer_id",
                principalTable: "Customers",
                principalColumn: "person_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auction_Details_Customers_current_buyer_id",
                table: "Auction_Details");

            migrationBuilder.AlterColumn<int>(
                name: "current_buyer_id",
                table: "Auction_Details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Auction_Details_Customers_current_buyer_id",
                table: "Auction_Details",
                column: "current_buyer_id",
                principalTable: "Customers",
                principalColumn: "person_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
