using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adopta_O_Emotie_Virtuala.Migrations
{
    public partial class _104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Foster_Parents",
                table: "Foster_Parents");

            migrationBuilder.RenameTable(
                name: "Foster_Parents",
                newName: "Foster_parents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foster_parents",
                table: "Foster_parents",
                column: "ID_Parent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Foster_parents",
                table: "Foster_parents");

            migrationBuilder.RenameTable(
                name: "Foster_parents",
                newName: "Foster_Parents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foster_Parents",
                table: "Foster_Parents",
                column: "ID_Parent");
        }
    }
}
