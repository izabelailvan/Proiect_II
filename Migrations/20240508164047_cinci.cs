using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adopta_O_Emotie_Virtuala.Migrations
{
    public partial class cinci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adoptions",
                columns: table => new
                {
                    ID_Adoption = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Animal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Parent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfAdoption = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptions", x => x.ID_Adoption);
                });

            migrationBuilder.CreateTable(
                name: "Foster_Parents",
                columns: table => new
                {
                    ID_Parent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_User = table.Column<int>(type: "int", nullable: false),
                    ExperienceWithAnimals = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prefrences = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foster_Parents", x => x.ID_Parent);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adoptions");

            migrationBuilder.DropTable(
                name: "Foster_Parents");
        }
    }
}
