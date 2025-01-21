using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamifySite_API.Migrations
{
    /// <inheritdoc />
    public partial class voucherChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoucherVendor",
                table: "Vouchers");

            migrationBuilder.RenameColumn(
                name: "ContactID",
                table: "Vendors",
                newName: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Vendors",
                newName: "ContactID");

            migrationBuilder.AddColumn<Guid>(
                name: "VoucherVendor",
                table: "Vouchers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
