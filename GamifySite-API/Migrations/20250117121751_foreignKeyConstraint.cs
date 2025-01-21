using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamifySite_API.Migrations
{
    /// <inheritdoc />
    public partial class foreignKeyConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vendors_UserID",
                table: "Vendors",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Users_UserID",
                table: "Vendors",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Users_UserID",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_UserID",
                table: "Vendors");
        }
    }
}
