using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamifySite_API.Migrations
{
    /// <inheritdoc />
    public partial class newChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_PayerUserID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaidBy",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Vendors",
                newName: "VendorAddressID");

            migrationBuilder.RenameColumn(
                name: "PayerUserID",
                table: "Payments",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_PayerUserID",
                table: "Payments",
                newName: "IX_Payments_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_VendorAddressID",
                table: "Vendors",
                column: "VendorAddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_UserID",
                table: "Payments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_VendorAddresses_VendorAddressID",
                table: "Vendors",
                column: "VendorAddressID",
                principalTable: "VendorAddresses",
                principalColumn: "VendorAddressID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_UserID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_VendorAddresses_VendorAddressID",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_VendorAddressID",
                table: "Vendors");

            migrationBuilder.RenameColumn(
                name: "VendorAddressID",
                table: "Vendors",
                newName: "AddressID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Payments",
                newName: "PayerUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_UserID",
                table: "Payments",
                newName: "IX_Payments_PayerUserID");

            migrationBuilder.AddColumn<Guid>(
                name: "PaidBy",
                table: "Payments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_PayerUserID",
                table: "Payments",
                column: "PayerUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
