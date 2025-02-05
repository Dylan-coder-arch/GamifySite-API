using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamifySite_API.Migrations
{
    /// <inheritdoc />
    public partial class newMapForVouchDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpinWinner_Users_WinnerID",
                table: "SpinWinner");

            migrationBuilder.DropForeignKey(
                name: "FK_VouchersDetail_Users_ClaimedUserUserID",
                table: "VouchersDetail");

            migrationBuilder.DropColumn(
                name: "ClaimedBy",
                table: "VouchersDetail");

            migrationBuilder.RenameColumn(
                name: "ClaimedUserUserID",
                table: "VouchersDetail",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_VouchersDetail_ClaimedUserUserID",
                table: "VouchersDetail",
                newName: "IX_VouchersDetail_UserID");

            migrationBuilder.RenameColumn(
                name: "WinnerID",
                table: "SpinWinner",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_SpinWinner_WinnerID",
                table: "SpinWinner",
                newName: "IX_SpinWinner_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_SpinWinner_Users_UserID",
                table: "SpinWinner",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VouchersDetail_Users_UserID",
                table: "VouchersDetail",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpinWinner_Users_UserID",
                table: "SpinWinner");

            migrationBuilder.DropForeignKey(
                name: "FK_VouchersDetail_Users_UserID",
                table: "VouchersDetail");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "VouchersDetail",
                newName: "ClaimedUserUserID");

            migrationBuilder.RenameIndex(
                name: "IX_VouchersDetail_UserID",
                table: "VouchersDetail",
                newName: "IX_VouchersDetail_ClaimedUserUserID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "SpinWinner",
                newName: "WinnerID");

            migrationBuilder.RenameIndex(
                name: "IX_SpinWinner_UserID",
                table: "SpinWinner",
                newName: "IX_SpinWinner_WinnerID");

            migrationBuilder.AddColumn<Guid>(
                name: "ClaimedBy",
                table: "VouchersDetail",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpinWinner_Users_WinnerID",
                table: "SpinWinner",
                column: "WinnerID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VouchersDetail_Users_ClaimedUserUserID",
                table: "VouchersDetail",
                column: "ClaimedUserUserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }
    }
}
