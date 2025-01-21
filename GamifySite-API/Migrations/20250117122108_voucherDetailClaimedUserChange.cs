using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamifySite_API.Migrations
{
    /// <inheritdoc />
    public partial class voucherDetailClaimedUserChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VouchersDetail_Users_ClaimedUserUserID",
                table: "VouchersDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClaimedUserUserID",
                table: "VouchersDetail",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_VouchersDetail_Users_ClaimedUserUserID",
                table: "VouchersDetail",
                column: "ClaimedUserUserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VouchersDetail_Users_ClaimedUserUserID",
                table: "VouchersDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClaimedUserUserID",
                table: "VouchersDetail",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VouchersDetail_Users_ClaimedUserUserID",
                table: "VouchersDetail",
                column: "ClaimedUserUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
