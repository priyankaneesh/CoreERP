using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreERP.Migrations
{
    /// <inheritdoc />
    public partial class UserAddToCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_LoginId",
                table: "Companies",
                column: "LoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Login_LoginId",
                table: "Companies",
                column: "LoginId",
                principalTable: "Login",
                principalColumn: "LoginId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Login_LoginId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_LoginId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "Companies");
        }
    }
}
