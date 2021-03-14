using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealer.Migrations
{
    public partial class changedtablenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car_Table");

            migrationBuilder.DropTable(
                name: "Dealer_table");

            migrationBuilder.CreateTable(
                name: "Dealer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: false),
                    State = table.Column<string>(maxLength: 30, nullable: false),
                    Phone = table.Column<string>(maxLength: 12, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    CarCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealerId = table.Column<int>(nullable: false),
                    Vin = table.Column<string>(maxLength: 17, nullable: false),
                    Make = table.Column<string>(maxLength: 30, nullable: false),
                    Model = table.Column<string>(maxLength: 30, nullable: false),
                    Trim = table.Column<string>(maxLength: 12, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 12, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal (11,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal (11,2)", nullable: false),
                    Profit = table.Column<decimal>(type: "decimal (11,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_Dealer_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_DealerId",
                table: "Car",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_Vin",
                table: "Car",
                column: "Vin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dealer_Code",
                table: "Dealer",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Dealer");

            migrationBuilder.CreateTable(
                name: "Dealer_table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarCount = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealer_table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car_Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal (11,2)", nullable: false),
                    DealerId = table.Column<int>(type: "int", nullable: false),
                    Dealer_TableId = table.Column<int>(type: "int", nullable: true),
                    Make = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Profit = table.Column<decimal>(type: "decimal (11,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal (11,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Trim = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Vin = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car_Table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_Table_Dealer_table_Dealer_TableId",
                        column: x => x.Dealer_TableId,
                        principalTable: "Dealer_table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_Table_Dealer_TableId",
                table: "Car_Table",
                column: "Dealer_TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_Table_Vin",
                table: "Car_Table",
                column: "Vin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dealer_table_Code",
                table: "Dealer_table",
                column: "Code",
                unique: true);
        }
    }
}
