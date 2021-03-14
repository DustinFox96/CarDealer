using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealer.Migrations
{
    public partial class Pleasework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dealer_table",
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
                    table.PrimaryKey("PK_Dealer_table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car_Table",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dealer_TableId = table.Column<int>(nullable: true),
                    DealerId = table.Column<int>(nullable: false),
                    Vin = table.Column<string>(maxLength: 17, nullable: false),
                    Make = table.Column<string>(maxLength: 30, nullable: false),
                    Model = table.Column<string>(maxLength: 30, nullable: false),
                    Trim = table.Column<string>(maxLength: 12, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 12, nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    SalePrice = table.Column<decimal>(nullable: false),
                    Profit = table.Column<decimal>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car_Table");

            migrationBuilder.DropTable(
                name: "Dealer_table");
        }
    }
}
