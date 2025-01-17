using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamifySite_API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spinners",
                columns: table => new
                {
                    SpinID = table.Column<Guid>(type: "uuid", nullable: false),
                    SpinName = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spinners", x => x.SpinID);
                });

            migrationBuilder.CreateTable(
                name: "TagsDef",
                columns: table => new
                {
                    TagDefID = table.Column<Guid>(type: "uuid", nullable: false),
                    TagName = table.Column<string>(type: "text", nullable: false),
                    TagColor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsDef", x => x.TagDefID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PhoneNo = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "VendorAddresses",
                columns: table => new
                {
                    VendorAddressID = table.Column<Guid>(type: "uuid", nullable: false),
                    StreetAddress = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorAddresses", x => x.VendorAddressID);
                });

            migrationBuilder.CreateTable(
                name: "VendorCategories",
                columns: table => new
                {
                    VendorCategoryID = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorCategories", x => x.VendorCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorID = table.Column<Guid>(type: "uuid", nullable: false),
                    VendorName = table.Column<string>(type: "text", nullable: false),
                    VendorCategoryID = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactID = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressID = table.Column<Guid>(type: "uuid", nullable: false),
                    VendorStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorID);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<Guid>(type: "uuid", nullable: false),
                    PaidBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PayerUserID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_Users_PayerUserID",
                        column: x => x.PayerUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    VoucherID = table.Column<Guid>(type: "uuid", nullable: false),
                    VoucherName = table.Column<string>(type: "text", nullable: false),
                    VoucherType = table.Column<string>(type: "text", nullable: false),
                    VoucherVendor = table.Column<Guid>(type: "uuid", nullable: false),
                    VoucherAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    VoucherExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VoucherStatus = table.Column<string>(type: "text", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    VoucherLocation = table.Column<string>(type: "text", nullable: false),
                    Visible = table.Column<bool>(type: "boolean", nullable: false),
                    Special1 = table.Column<bool>(type: "boolean", nullable: false),
                    Special2 = table.Column<bool>(type: "boolean", nullable: false),
                    Special3 = table.Column<bool>(type: "boolean", nullable: false),
                    VendorID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.VoucherID);
                    table.ForeignKey(
                        name: "FK_Vouchers_Vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingID = table.Column<Guid>(type: "uuid", nullable: false),
                    VoucherID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    RatingValue = table.Column<decimal>(type: "numeric", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingID);
                    table.ForeignKey(
                        name: "FK_Rating_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Vouchers_VoucherID",
                        column: x => x.VoucherID,
                        principalTable: "Vouchers",
                        principalColumn: "VoucherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpinnersPrize",
                columns: table => new
                {
                    SpinPrizeID = table.Column<Guid>(type: "uuid", nullable: false),
                    SpinID = table.Column<Guid>(type: "uuid", nullable: false),
                    VoucherID = table.Column<Guid>(type: "uuid", nullable: false),
                    Probability = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpinnersPrize", x => x.SpinPrizeID);
                    table.ForeignKey(
                        name: "FK_SpinnersPrize_Spinners_SpinID",
                        column: x => x.SpinID,
                        principalTable: "Spinners",
                        principalColumn: "SpinID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpinnersPrize_Vouchers_VoucherID",
                        column: x => x.VoucherID,
                        principalTable: "Vouchers",
                        principalColumn: "VoucherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagID = table.Column<Guid>(type: "uuid", nullable: false),
                    VoucherID = table.Column<Guid>(type: "uuid", nullable: false),
                    TagDefID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagID);
                    table.ForeignKey(
                        name: "FK_Tags_TagsDef_TagDefID",
                        column: x => x.TagDefID,
                        principalTable: "TagsDef",
                        principalColumn: "TagDefID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tags_Vouchers_VoucherID",
                        column: x => x.VoucherID,
                        principalTable: "Vouchers",
                        principalColumn: "VoucherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VouchersDetail",
                columns: table => new
                {
                    VoucherDetailID = table.Column<Guid>(type: "uuid", nullable: false),
                    VoucherCode = table.Column<string>(type: "text", nullable: false),
                    VoucherCodeStatus = table.Column<string>(type: "text", nullable: false),
                    VoucherID = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ClaimedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ClaimedUserUserID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VouchersDetail", x => x.VoucherDetailID);
                    table.ForeignKey(
                        name: "FK_VouchersDetail_Users_ClaimedUserUserID",
                        column: x => x.ClaimedUserUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VouchersDetail_Vouchers_VoucherID",
                        column: x => x.VoucherID,
                        principalTable: "Vouchers",
                        principalColumn: "VoucherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpinWinner",
                columns: table => new
                {
                    SpinWinnerID = table.Column<Guid>(type: "uuid", nullable: false),
                    SpinPrizeID = table.Column<Guid>(type: "uuid", nullable: false),
                    WinnerID = table.Column<Guid>(type: "uuid", nullable: false),
                    DateWon = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpinWinner", x => x.SpinWinnerID);
                    table.ForeignKey(
                        name: "FK_SpinWinner_SpinnersPrize_SpinPrizeID",
                        column: x => x.SpinPrizeID,
                        principalTable: "SpinnersPrize",
                        principalColumn: "SpinPrizeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpinWinner_Users_WinnerID",
                        column: x => x.WinnerID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PayerUserID",
                table: "Payments",
                column: "PayerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserID",
                table: "Rating",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_VoucherID",
                table: "Rating",
                column: "VoucherID");

            migrationBuilder.CreateIndex(
                name: "IX_SpinnersPrize_SpinID",
                table: "SpinnersPrize",
                column: "SpinID");

            migrationBuilder.CreateIndex(
                name: "IX_SpinnersPrize_VoucherID",
                table: "SpinnersPrize",
                column: "VoucherID");

            migrationBuilder.CreateIndex(
                name: "IX_SpinWinner_SpinPrizeID",
                table: "SpinWinner",
                column: "SpinPrizeID");

            migrationBuilder.CreateIndex(
                name: "IX_SpinWinner_WinnerID",
                table: "SpinWinner",
                column: "WinnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TagDefID",
                table: "Tags",
                column: "TagDefID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_VoucherID",
                table: "Tags",
                column: "VoucherID");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_VendorID",
                table: "Vouchers",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_VouchersDetail_ClaimedUserUserID",
                table: "VouchersDetail",
                column: "ClaimedUserUserID");

            migrationBuilder.CreateIndex(
                name: "IX_VouchersDetail_VoucherID",
                table: "VouchersDetail",
                column: "VoucherID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "SpinWinner");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "VendorAddresses");

            migrationBuilder.DropTable(
                name: "VendorCategories");

            migrationBuilder.DropTable(
                name: "VouchersDetail");

            migrationBuilder.DropTable(
                name: "SpinnersPrize");

            migrationBuilder.DropTable(
                name: "TagsDef");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Spinners");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
