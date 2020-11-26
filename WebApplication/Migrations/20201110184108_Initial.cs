using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    BrandName = table.Column<string>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(fixedLength: true, maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarTrim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    CarModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTrim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarTrim_CarModel_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    ModelName = table.Column<string>(nullable: false),
                    TrimName = table.Column<string>(nullable: false),
                    Engine = table.Column<string>(nullable: false),
                    FuelType = table.Column<string>(nullable: false),
                    GearType = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    BankLoanDuration = table.Column<int>(nullable: false),
                    BankLoanDownPayment = table.Column<decimal>(nullable: false),
                    BankLoanMonthlyPayment = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarVariant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Engine = table.Column<string>(nullable: true),
                    FuelType = table.Column<string>(nullable: false),
                    GearType = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    CarTrimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarVariant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarVariant_CarTrim_CarTrimId",
                        column: x => x.CarTrimId,
                        principalTable: "CarTrim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_Name",
                table: "CarModel",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarOrder_CustomerId",
                table: "CarOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarTrim_CarModelId",
                table: "CarTrim",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarVariant_CarTrimId",
                table: "CarVariant",
                column: "CarTrimId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email",
                table: "Customer",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarOrder");

            migrationBuilder.DropTable(
                name: "CarVariant");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "CarTrim");

            migrationBuilder.DropTable(
                name: "CarModel");
        }
    }
}
