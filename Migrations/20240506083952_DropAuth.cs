using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITSA_Delon_Jarrod_naidoo.Migrations
{
    /// <inheritdoc />
    public partial class DropAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auth",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    password_hashed = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    salt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth", x => x.id);
                });
        }
    }
}
