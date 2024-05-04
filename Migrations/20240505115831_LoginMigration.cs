using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITSA_Delon_Jarrod_naidoo.Migrations
{
    /// <inheritdoc />
    public partial class LoginMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "VoltageAmperage",
                table: "Meters",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "MeterId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Address_MeterId",
                table: "Address",
                column: "MeterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Meters_MeterId",
                table: "Address",
                column: "MeterId",
                principalTable: "Meters",
                principalColumn: "MeterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Meters_MeterId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_MeterId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "MeterId",
                table: "Address");

            migrationBuilder.AlterColumn<double>(
                name: "VoltageAmperage",
                table: "Meters",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
