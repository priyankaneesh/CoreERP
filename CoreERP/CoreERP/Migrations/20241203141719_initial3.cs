using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreERP.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_StatusCodes_StatusCodeNavigationStatusCode1",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_StatusCodeNavigationStatusCode1",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "StatusCodeNavigationStatusCode1",
                table: "Vendors");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_StatusCode",
                table: "Vendors",
                column: "StatusCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_StatusCodes_StatusCode",
                table: "Vendors",
                column: "StatusCode",
                principalTable: "StatusCodes",
                principalColumn: "StatusCode1",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_StatusCodes_StatusCode",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_StatusCode",
                table: "Vendors");

            migrationBuilder.AddColumn<int>(
                name: "StatusCodeNavigationStatusCode1",
                table: "Vendors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_StatusCodeNavigationStatusCode1",
                table: "Vendors",
                column: "StatusCodeNavigationStatusCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_StatusCodes_StatusCodeNavigationStatusCode1",
                table: "Vendors",
                column: "StatusCodeNavigationStatusCode1",
                principalTable: "StatusCodes",
                principalColumn: "StatusCode1",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
